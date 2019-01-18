using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TRTLFarm.Data;
using TRTLFarm.Models;
using TRTLFarm.Services;
using TRTLFarm.Services.ServiceModels;
using TRTLFarm.ViewModels;

namespace TRTLFarm.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IViewRenderService _viewRenderService;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;


        public AdminController(IServiceProvider serviceProvider, 
            IViewRenderService viewRenderService, 
            ApplicationDbContext db)
        {
            this._serviceProvider = serviceProvider;
            this._viewRenderService = viewRenderService;
            this._db = db;
            _userManager = _serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        }
        public IActionResult Index()
        {
            AdminModel model = new AdminModel();
            model = _db.AdminModel.FirstOrDefault();
            model.Balance = TRTLService.GetTRTLBalance(model.PaymentAddress).availableBalance;

            return View(model);
        }
    }
}