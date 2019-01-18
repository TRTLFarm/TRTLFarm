using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TRTLFarm.Data;
using TRTLFarm.Models;
using TRTLFarm.Services;
using TRTLFarm.Services.ServiceModels;

namespace TRTLFarm.Areas.Identity.Pages.Account.Manage
{
    public partial class DepositHistoryModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _db;

        public DepositHistoryModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this._db = db;
        }


        public List<Deposit> Deposits { get; set; }

        [TempData]
        public string StatusMessage { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userName = await _userManager.GetUserNameAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            Deposits = _db.Deposits.Where(d => d.paymentId == user.TRTLPaymentId).OrderByDescending(d => d.Id).ToList();
          
            return Page();
        }

       
    }
}
