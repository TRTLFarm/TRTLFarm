using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TRTLFarm.Data;
using TRTLFarm.Models;
using TRTLFarm.Services;
using TRTLFarm.Services.ServiceModels;
using TRTLFarm.ViewModels;

namespace TRTLFarm.Controllers
{
    public class MarketController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IServiceProvider _serviceProvider;
        public MarketController(ApplicationDbContext db, IServiceProvider serviceProvider)
        {
            this._db = db;
            this._serviceProvider = serviceProvider;
        }
        [Authorize]
        public IActionResult Index()
        {
            List<Animal> model = new List<Animal>();
            model = _db.Animals.ToList();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Buy(Animal animal)
        {
            if (ModelState.IsValid)
            {
                if (animal.Quantity > 0)
                {
                    var _userManager = _serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    ApplicationUser user = await _userManager.GetUserAsync(User);
                    decimal animalPrice = _db.Animals.Where(a => a.Id == animal.Id).Select(a => a.Price).FirstOrDefault();
                    decimal pricetoBuy = animal.Quantity * animalPrice;
                    if (user.TRTLBalance >= pricetoBuy)
                    {
                        var userAnimal = _db.UserAnimals.Where(ua => ua.AnimalId == animal.Id && ua.UserId == user.Id).FirstOrDefault();
                        if (userAnimal != null)
                        {
                            userAnimal.AnimalCount += animal.Quantity;
                            _db.UserAnimals.Update(userAnimal);
                        }
                        else
                        {
                            _db.UserAnimals.Add(new UserAnimals() { AnimalId = animal.Id, AnimalCount = animal.Quantity, LastClaimTime = DateTime.UtcNow, UserId = user.Id });
                        }

                        user.TRTLBalance -= pricetoBuy;
                        await _userManager.UpdateAsync(user);
                        _db.SaveChanges();
                        TempData["SUCCESS"] = animal.Quantity + " " + animal.Name + " successfully added to your farm";
                    }
                    else
                    {
                        TempData["ERROR"] = "Not enough funds on your account";
                    }
                }
            }
            return RedirectToAction("Index");
        }


        [Authorize]
        public float getAmountFee(decimal amount)
        {
            return TRTLService.GetTRTLFee(float.Parse(amount.ToString()));
        }



        [Authorize]
        public async Task<IActionResult> Sell()
        {
            var _userManager = _serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            ApplicationUser user = await _userManager.GetUserAsync(User);
            SellModel model = new SellModel();
            model.OwnedAnimals = _db.UserAnimals.Where(ua => ua.UserId == user.Id).Include(ua => ua.Animal).ToList();
            model.UnitPrice = getAnimalProducePrice();

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SellProduce(UserAnimals model)
        {
            if (ModelState.IsValid)
            {
                var _userManager = _serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                ApplicationUser user = await _userManager.GetUserAsync(User);
                UserAnimals DBmodel = _db.UserAnimals.Where(ua => ua.UserId == user.Id && ua.Id == model.Id).Include(ua => ua.Animal).FirstOrDefault();
                if (DBmodel != null)
                {
                    decimal UnitPrice = getAnimalProducePrice();
                    decimal PriceToAddToBalance = UnitPrice * DBmodel.ClaimedProduceCount;
                    user.TRTLBalance += PriceToAddToBalance;
                    _db.Users.Update(user);
                    DBmodel.ClaimedProduceCount = 0;
                    _db.UserAnimals.Update(DBmodel);
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Sell");
        }


        private decimal getAnimalProducePrice()
        {
            AdminModel adminModel = _db.AdminModel.FirstOrDefault();
            AddressBalance balance = TRTLService.GetTRTLBalance(adminModel.PaymentAddress);
            decimal allDeposits = balance.availableBalance;
            var allAnimals = _db.Animals.ToList();
            var allUserAnimals = _db.UserAnimals.GroupBy(ua => ua.AnimalId).ToList();
            long totalClaimCount = 0;
            foreach (var userAnimal in allUserAnimals)
            {
                var tmpSum = userAnimal.Sum(ua => ua.AnimalCount) * allAnimals.Where(a => a.Id == userAnimal.First().AnimalId).FirstOrDefault().ProductionSpeed;
                totalClaimCount += Convert.ToInt64(tmpSum);
            }
            decimal unitPrice = 0;
            if (totalClaimCount > 0)
            {
                unitPrice = allDeposits / totalClaimCount / 60;//ROI factor HARDCODED - at least 60 days(if you count off refs and other factors)
            }
            return unitPrice;
        }


        [HttpPost]
        public void TRTLWebHook(string type, [FromBody]string value)
        {
            Request.EnableRewind();
            string jsonData = string.Empty;
            using (var reader = new StreamReader(Request.Body))
            {
                jsonData = reader.ReadToEnd();
                Request.Body.Seek(0, SeekOrigin.Begin);
                jsonData = reader.ReadToEnd();
            }
            _db.WebHookMessages.Add(new WebHookMessages() { Message = jsonData });
            var authorization = Request.Headers["authorization"];
            if (ConfigurationManager.AppSetting["ExtendedLogging"] == "1")
            {
                _db.WebHookMessages.Add(new WebHookMessages() { Message = authorization });
            }
            _db.SaveChanges();
            string authenticationToken = ConfigurationManager.AppSetting["WebHookAuthenitcation"].ToString();
            if (authorization.ToString() == authenticationToken)
            {
                if (ConfigurationManager.AppSetting["ExtendedLogging"] == "1")
                {
                    _db.WebHookMessages.Add(new WebHookMessages() { Message = "Auth successfull" });
                    _db.SaveChanges();
                }

                dynamic obj = JsonConvert.DeserializeObject(jsonData);
                string transactionHash = string.Empty;
                int confirms = 0;
                decimal amount = decimal.Zero;
                decimal fee = decimal.Zero;
                long timestamp = 0;
                int blockIndex = 0;
                switch (type)
                {
                    case "receive":
                        string address = obj.address;
                        amount = obj.amount;
                        fee = obj.fee;
                        transactionHash = obj.transactionHash;
                        string blockHash = obj.blockHash;
                        string paymentId = obj.paymentId;
                        string extra = obj.extra;
                        timestamp = obj.timestamp;
                        blockIndex = obj.blockIndex;
                        confirms = obj.confirms;
                        Deposit deposit = new Deposit() { address = address, amount = amount, fee = fee, transactionHash = transactionHash, blockHash = blockHash, paymentId = paymentId, extra = extra, timestamp = timestamp, blockIndex = blockIndex, confirms = confirms };
                        if (_db.Deposits.Where(d => d.transactionHash == transactionHash).FirstOrDefault() == null)
                        {
                            _db.Deposits.Add(deposit);
                            _db.SaveChanges();
                            processConfirmedDepositstoUsers();
                        }
                        break;
                    case "send":
                        string addressTo = obj.addressTo;
                        string addressFrom = obj.addressFrom;
                        amount = obj.amount;
                        fee = obj.fee;
                        decimal sfee = obj.sfee;
                        transactionHash = obj.transactionHash;
                        timestamp = obj.timestamp;
                        blockIndex = obj.blockIndex;
                        confirms = obj.confirms;
                        var existingWithdrawal = _db.Withdrawals.Where(d => d.transactionHash == transactionHash).FirstOrDefault();
                        if (existingWithdrawal != null)
                        {
                            existingWithdrawal.addressTo = addressTo;
                            existingWithdrawal.addressFrom = addressFrom;
                            existingWithdrawal.amount = amount;
                            existingWithdrawal.fee = fee;
                            existingWithdrawal.sfee = sfee;
                            existingWithdrawal.timestamp = timestamp;
                            existingWithdrawal.blockIndex = blockIndex;
                            existingWithdrawal.confirms = confirms;

                            _db.Withdrawals.Update(existingWithdrawal);
                        }
                        else
                        {
                            _db.Withdrawals.Add(new Withdrawal() { addressTo = addressTo, addressFrom = addressFrom, amount = amount, fee = fee, sfee = sfee, transactionHash = transactionHash, timestamp = timestamp, blockIndex = blockIndex, confirms = confirms });
                        }
                        _db.SaveChanges();
                        break;
                    case "confirm":
                        transactionHash = obj.transactionHash;
                        string typeInOut = obj.type;
                        confirms = obj.confirms;
                        if (typeInOut != null && typeInOut.Length > 0)
                        {
                            switch (typeInOut)
                            {
                                case "in":
                                    var existingDeposit = _db.Deposits.Where(d => d.transactionHash == transactionHash).FirstOrDefault();
                                    if (existingDeposit != null)
                                    {
                                        existingDeposit.confirms = confirms;
                                        _db.Deposits.Update(existingDeposit);
                                        _db.SaveChanges();
                                        processConfirmedDepositstoUsers();
                                    }
                                    break;
                                case "out":
                                    var existingWithdrawalConfirm = _db.Withdrawals.Where(d => d.transactionHash == transactionHash).FirstOrDefault();
                                    if (existingWithdrawalConfirm != null)
                                    {
                                        existingWithdrawalConfirm.confirms = confirms;
                                        _db.Withdrawals.Update(existingWithdrawalConfirm);
                                        _db.SaveChanges();
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }

                        break;
                    default:
                        break;

                }

            }
        }


        private void processConfirmedDepositstoUsers()
        {
            var confirmed = _db.Deposits.Where(d => d.confirms >= 10 && d.AddedToBalance == false).ToList();
            foreach (var deposit in confirmed)
            {
                var user = _db.Users.Where(u => u.TRTLPaymentId == deposit.paymentId).FirstOrDefault();
                if(user != null)
                {
                    user.TRTLBalance += deposit.amount;
                    user.TRTLDepositedTotal += deposit.amount;
                    deposit.AddedToBalance = true;
                    _db.Users.Update(user);
                    _db.Deposits.Update(deposit);
                    /*add 5% to balance of referer if exists*/
                    if(user.RefCodeUsed != null && user.RefCodeUsed.Length > 0)
                    {
                        var referer = _db.Users.Where(u => u.RefCode == user.RefCodeUsed).FirstOrDefault();
                        if(referer != null)
                        {
                            decimal refererCut = (deposit.amount * (decimal)(0.05));
                            referer.TRTLBalance += refererCut;
                            referer.RefRewards += refererCut;
                            _db.Users.Update(referer);
                            _db.WebHookMessages.Add(new WebHookMessages() { Message = "User " + referer.Email + " got " + refererCut + " from "+ user.Email + " as referal bonus"});
                        }
                    }
                }
            }
            _db.SaveChanges();
        }


    }
}