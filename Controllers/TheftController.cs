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
    }
}