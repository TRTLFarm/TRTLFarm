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

namespace TRTLFarm.Areas.Identity.Pages.Account.Manage
{
    public partial class BalanceModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _db;

        public BalanceModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            this._db = db;
        }

        public string Username { get; set; }

        [Display(Name = "Your TurtleCoin address")]
        public string TRTLAddress { get; set; }

        [Display(Name = "Your TurtleCoin balance")]
        public decimal TRTLGameBalance { get; set; }

        [Display(Name = "Your payment id")]
        public string TRTLPaymentId { get; set; }

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
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            var TRTLPaymentIdExisting = user.TRTLPaymentId;
            if(TRTLPaymentIdExisting != null && TRTLPaymentIdExisting.Length > 0)
            {
                TRTLPaymentId = TRTLPaymentIdExisting;
            }
            else
            {
                TRTLPaymentIdExisting = TRTLService.GetPaymentId();
                user.TRTLPaymentId = TRTLPaymentIdExisting;
                TRTLPaymentId = TRTLPaymentIdExisting;
                await _userManager.UpdateAsync(user);
            }
            
            Username = userName;
            if (_db.AdminModel.Count() > 0)
            {
                TRTLAddress = _db.AdminModel.FirstOrDefault().PaymentAddress;
            }
            else
            {
                TRTLAddress = "Please contact administrator";
            }
            return Page();
        }

       
    }
}
