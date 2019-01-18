using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRTLFarm.Data;
using TRTLFarm.Services;
using TRTLFarm.ViewModels;

namespace TRTLFarm.Components
{
    [ViewComponent(Name = "FooterStats")]
    public class FooterStatsViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public FooterStatsViewComponent(ApplicationDbContext db)
        {
            this._db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            FooterStats model = new FooterStats();
            model.ActivePlayers = _db.Users.Where(u => u.EmailConfirmed == true).Count();
            var adminModel = _db.AdminModel.FirstOrDefault();
            if (adminModel != null)
            {
                model.WalletBalance = TRTLService.GetTRTLBalance(adminModel.PaymentAddress).availableBalance;
            }
            return View(model);
        }

    }
}
