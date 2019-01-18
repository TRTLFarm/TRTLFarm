using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TRTLFarm.Data;
using TRTLFarm.Models;
using TRTLFarm.Services;
using TRTLFarm.Services.ServiceModels;
using TRTLFarm.ViewModels;

namespace TRTLFarm.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IViewRenderService _viewRenderService;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(IServiceProvider serviceProvider, IViewRenderService viewRenderService, ApplicationDbContext db)
        {
            this._serviceProvider = serviceProvider;
            this._viewRenderService = viewRenderService;
            this._db = db;
            _userManager = _serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        }

        public async Task<IActionResult> Index()
        {
            HomeModel model = new HomeModel();
            ApplicationUser user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                model.OwnedAnimals = _db.UserAnimals.Where(ua => ua.UserId == user.Id).Include(ua => ua.Animal).ToList();
                string paymentid = TRTLService.GetPaymentId();
            }
           
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Claim(UserAnimals model)
        {
            if (ModelState.IsValid)
            {
                var _userManager = _serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                ApplicationUser user = await _userManager.GetUserAsync(User);
                var animal = _db.UserAnimals.Where(ua => ua.UserId == user.Id && ua.AnimalId == model.AnimalId).Include(ua => ua.Animal).FirstOrDefault();
                if (user != null && animal != null)
                {
                    DateTime now = DateTime.UtcNow;
                    double secondsDif = (now - animal.LastClaimTime).TotalSeconds;
                    int intProduce = (int)((secondsDif / animal.Animal.ProductionTimeSeconds) * animal.AnimalCount * decimal.ToDouble(animal.Animal.ProductionSpeed));
                    if (intProduce > 0)
                    {
                        animal.ClaimedProduceCount += intProduce;
                        /*Add time that it needs to produce intProduce production, so decimals stays*/
                        decimal secondsToAdd = 0;
                        secondsToAdd = ((animal.Animal.ProductionTimeSeconds / animal.AnimalCount) / animal.Animal.ProductionSpeed) * intProduce;
                        animal.LastClaimTime = animal.LastClaimTime.AddSeconds(Decimal.ToDouble(secondsToAdd));
                        _db.UserAnimals.Update(animal);
                        _db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> Referal()
        {
            ReferalModel model = new ReferalModel();
            ApplicationUser user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                if(user.RefCode == null || user.RefCode.Length == 0)
                {
                    user.RefCode = Guid.NewGuid().ToString();
                    await _userManager.UpdateAsync(user);
                }
                model.ReferalLink = "https://trtlfarm.com/Identity/Account/Register?refCode=" + user.RefCode;
                model.ReferalCount = _db.Users.Where(u => u.RefCodeUsed == user.RefCode).Count();
                model.ReferalCommisonsTRTL = user.RefRewards;
            }
            return View("~/Views/Home/Referal.cshtml", model);
        }

        public IActionResult TermsAndConditions()
        {
            return View("~/Views/Home/TermsAndConditions.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
