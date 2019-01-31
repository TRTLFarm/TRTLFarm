using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TRTLFarm.Data;
using TRTLFarm.Models;
using TRTLFarm.ViewModels;

namespace TRTLFarm.Controllers
{
    [Authorize]
    public class TheftController : Controller
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public TheftController(IServiceProvider serviceProvider, ApplicationDbContext db)
        {
            this._serviceProvider = serviceProvider;
            this._db = db;
            _userManager = _serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        }


        public async Task<IActionResult> Index()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            TheftIndexModel model = new TheftIndexModel();
            using (var dr = await _db.Database.ExecuteSqlQueryAsync(@"exec _sp_getUnclaimedProduction"))
            {
                var reader = dr.DbDataReader;
                while (reader.Read())
                {
                    model.UnclaimedProductions.Add(new UnclaimedProduction()
                    {
                        prodFromLastClaim = (decimal)reader.GetDecimal(0),
                        perSecond = reader.GetDecimal(1),
                        UserId = reader.GetString(2),
                        AnimalId = reader.GetInt32(3),
                        AnimalCount = reader.GetInt32(4),
                        LastClaimTime = reader.GetDateTime(5),
                        ProductionSpeed = reader.GetDecimal(6),
                        ProductionTimeSeconds = reader.GetInt32(7),
                        TRTLPaymentId = reader.GetString(8),
                        Nickname = reader[9] != DBNull.Value ? reader.GetString(9) : "",
                        UnclaimedId = reader.GetInt32(10),
                        SafeZone = reader[11] != DBNull.Value ? reader.GetInt32(11) : 0
                    });
                }
            }
            decimal YourTotalProduction = decimal.Zero;
            var OwnedAnimals = _db.UserAnimals.Where(ua => ua.UserId == user.Id).Include(ua => ua.Animal).ToList();
            var OwnedSpecialAnimals = _db.SpecialAnimals.Where(ua => ua.OwnerUserId == user.Id).ToList();
            foreach (var animal in OwnedAnimals)
            {
                YourTotalProduction += (animal.AnimalCount * animal.Animal.ProductionSpeed);
            }
            /*check if you own any special and add it here*/
            if (OwnedSpecialAnimals != null)
            {
                foreach (var mySpecialAnimal in OwnedSpecialAnimals)
                {
                    YourTotalProduction += mySpecialAnimal.ProductionSpeed;
                }
            }
            if (YourTotalProduction > 0)
            {
                model.YourHourlyStealPower = (int)(YourTotalProduction / 24);
            }

            var theftCooldown = _db.TheftCooldown.Where(tc => tc.UserId == user.Id).FirstOrDefault();
            if (theftCooldown != null)
            {
                int timeFromLastAttack = (int)(DateTime.UtcNow - theftCooldown.LastUserAttack).TotalSeconds - 7200;/*You can attack once per 2 hours*/
                if (timeFromLastAttack < 0)
                {
                    model.SecondsCooldown = Math.Abs(timeFromLastAttack);
                }
                else
                {
                    model.SecondsCooldown = 0;
                }
            }
            else
            {
                model.SecondsCooldown = 0;
            }

            return View(model);
        }


        [Authorize]
        public async Task<IActionResult> Steal(int UnclaimedId)
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            /*check cooldown for enemy and yourself*/
            var theftCooldown = _db.TheftCooldown.Where(tc => tc.UserId == user.Id).FirstOrDefault();
            if (theftCooldown != null)
            {
                int timeFromLastAttack = (int)(DateTime.UtcNow - theftCooldown.LastUserAttack).TotalSeconds - 7200;/*2 hours*/
                if (timeFromLastAttack < 0)
                {
                    TempData["ERROR"] = "You can't attack yet. You still have cooldown of " + Math.Abs(timeFromLastAttack) + " seconds";
                    return RedirectToAction("Index");
                }
            }
            var unclaimedToAtack = _db.UserAnimals.Where(ua => ua.Id == UnclaimedId).Include(ua => ua.Animal).FirstOrDefault();
            if (unclaimedToAtack != null)
            {
                var userToAttackCooldown = _db.TheftCooldown.Where(tc => tc.UserId == unclaimedToAtack.UserId).FirstOrDefault();
                if (userToAttackCooldown != null)
                {
                    int timeFromLastAttack = (int)(DateTime.UtcNow - userToAttackCooldown.LastBeenAtacked).TotalSeconds - 7200;/*Safe for 60 minutes*/
                    if (timeFromLastAttack < 0)
                    {
                        TempData["ERROR"] = "You can't attack this player yet. His safe zone is still " + Math.Abs(timeFromLastAttack) + " seconds";
                        return RedirectToAction("Index");
                    }
                }

                if (user.Id == unclaimedToAtack.UserId)
                {
                    TempData["ERROR"] = "You can't attack yourself lol....";
                    return RedirectToAction("Index");
                }

                /*Calculate stealing capacity*/
                decimal stealPower = decimal.Zero;
                decimal YourTotalProduction = decimal.Zero;
                var OwnedAnimals = _db.UserAnimals.Where(ua => ua.UserId == user.Id).Include(ua => ua.Animal).ToList();
                var OwnedSpecialAnimals = _db.SpecialAnimals.Where(ua => ua.OwnerUserId == user.Id).ToList();
                foreach (var animal in OwnedAnimals)
                {
                    YourTotalProduction += (animal.AnimalCount * animal.Animal.ProductionSpeed);
                }
                /*check if you own any special and add it here*/
                if (OwnedSpecialAnimals != null)
                {
                    foreach (var mySpecialAnimal in OwnedSpecialAnimals)
                    {
                        YourTotalProduction += mySpecialAnimal.ProductionSpeed;
                    }
                }
                if (YourTotalProduction > 0)
                {
                    stealPower = (int)(YourTotalProduction / 24);
                    if ((int)(stealPower) > 0)
                    {
                        /*Calculate unclaimed count from this useranimal*/
                        DateTime now = DateTime.UtcNow;
                        double secondsDif = (now - unclaimedToAtack.LastClaimTime).TotalSeconds;
                        decimal Produce = Convert.ToDecimal((secondsDif / unclaimedToAtack.Animal.ProductionTimeSeconds) * unclaimedToAtack.AnimalCount * decimal.ToDouble(unclaimedToAtack.Animal.ProductionSpeed));
                        if (Produce > 0)
                        {
                            if (stealPower >= Produce)
                            {
                                /*get current user's first useranimal*/
                                var firstUsersAnimal = OwnedAnimals.FirstOrDefault();
                                if (firstUsersAnimal != null)
                                {
                                    firstUsersAnimal.ClaimedProduceCount += (int)Produce; /*add to current user*/
                                    unclaimedToAtack.LastClaimTime = DateTime.UtcNow;
                                    _db.UserAnimals.Update(firstUsersAnimal);
                                    _db.UserAnimals.Update(unclaimedToAtack);
                                    if (theftCooldown == null)
                                    {
                                        _db.TheftCooldown.Add(new TheftCooldown() { UserId = user.Id, LastUserAttack = DateTime.UtcNow, TotalStealCount = (int)Produce, LastBeenAtacked = DateTime.UtcNow.AddYears(-1) });
                                    }
                                    else
                                    {
                                        theftCooldown.TotalStealCount += (int)Produce;
                                        theftCooldown.LastUserAttack = DateTime.UtcNow;
                                        _db.TheftCooldown.Update(theftCooldown);
                                    }
                                    if (userToAttackCooldown == null)
                                    {
                                        _db.TheftCooldown.Add(new TheftCooldown() { UserId = unclaimedToAtack.UserId, LastUserAttack = DateTime.UtcNow.AddYears(-1), LastBeenAtacked = DateTime.UtcNow });
                                    }
                                    else
                                    {
                                        userToAttackCooldown.LastBeenAtacked = DateTime.UtcNow;
                                        _db.TheftCooldown.Update(userToAttackCooldown);
                                    }
                                    _db.UserLogHistory.Add(new UserLogHistory()
                                    {
                                        LogType = "Message",
                                        LogMessage = "You stole " + (int)Produce + " production",
                                        UserId = user.Id,
                                        Action = "Steal",
                                        Date = DateTime.UtcNow
                                    });
                                    _db.UserLogHistory.Add(new UserLogHistory()
                                    {
                                        LogType = "Message",
                                        LogMessage = "You lost " + (int)Produce + " production",
                                        UserId = unclaimedToAtack.UserId,
                                        Action = "Steal",
                                        Date = DateTime.UtcNow
                                    });
                                    _db.SaveChanges();
                                    TempData["SUCCESS"] = "You stole " + (int)Produce + " production";
                                    return RedirectToAction("Index");
                                }
                            }
                            else
                            {
                                var firstUsersAnimal = OwnedAnimals.FirstOrDefault();
                                if (firstUsersAnimal != null)
                                {
                                    firstUsersAnimal.ClaimedProduceCount += (int)stealPower;
                                    /*Calculate time to add to lastclaim time based on stealpower*/
                                    decimal secondsToAdd = decimal.Zero;
                                    secondsToAdd = ((unclaimedToAtack.Animal.ProductionTimeSeconds / unclaimedToAtack.AnimalCount) / unclaimedToAtack.Animal.ProductionSpeed) * (int)stealPower;
                                    unclaimedToAtack.LastClaimTime = unclaimedToAtack.LastClaimTime.AddSeconds(Decimal.ToDouble(secondsToAdd));
                                    _db.UserAnimals.Update(unclaimedToAtack);
                                    _db.UserAnimals.Update(firstUsersAnimal);
                                    if (theftCooldown == null)
                                    {
                                        _db.TheftCooldown.Add(new TheftCooldown() { UserId = user.Id, LastUserAttack = DateTime.UtcNow, TotalStealCount = (int)stealPower, LastBeenAtacked = DateTime.UtcNow.AddYears(-1) });
                                    }
                                    else
                                    {
                                        theftCooldown.TotalStealCount += (int)stealPower;
                                        theftCooldown.LastUserAttack = DateTime.UtcNow;
                                        _db.TheftCooldown.Update(theftCooldown);
                                    }
                                    if (userToAttackCooldown == null)
                                    {
                                        _db.TheftCooldown.Add(new TheftCooldown() { UserId = unclaimedToAtack.UserId, LastUserAttack = DateTime.UtcNow.AddYears(-1), LastBeenAtacked = DateTime.UtcNow });
                                    }
                                    else
                                    {
                                        userToAttackCooldown.LastBeenAtacked = DateTime.UtcNow;
                                        _db.TheftCooldown.Update(userToAttackCooldown);
                                    }
                                    _db.UserLogHistory.Add(new UserLogHistory()
                                    {
                                        LogType = "Message",
                                        LogMessage = "You stole " + (int)stealPower + " production",
                                        UserId = user.Id,
                                        Action = "Steal",
                                        Date = DateTime.UtcNow
                                    });
                                    _db.UserLogHistory.Add(new UserLogHistory()
                                    {
                                        LogType = "Message",
                                        LogMessage = "You lost " + (int)stealPower + " production",
                                        UserId = unclaimedToAtack.UserId,
                                        Action = "Steal",
                                        Date = DateTime.UtcNow
                                    });
                                    _db.SaveChanges();
                                    TempData["SUCCESS"] = "You stole " + (int)stealPower + " production";
                                    return RedirectToAction("Index");
                                }
                            }
                        }
                    }
                }
            }

            return RedirectToAction("Index");
        }


    }
}