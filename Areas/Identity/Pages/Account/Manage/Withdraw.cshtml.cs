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
    public partial class WithdrawModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _db;

        public WithdrawModel(
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

        [TempData]
        public string StatusMessage { get; set; }


        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
          

            [Required]
            [Display(Name = "Your TurtleCoin address")]
            public string WithdrawAddress { get; set; }

            [Required]
            [Display(Name = "Amout")]
            public int WithdrawAmount { get; set; }
        }


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
            Username = userName;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            if (Input.WithdrawAmount < 20)
            {
                TempData["ERROR"] = "Minimum withdrawal is 20 TRTL";
                return Page();
            }
            if (Input.WithdrawAmount > user.TRTLBalance)
            {
                TempData["ERROR"] = "You tried to withdraw more than you have";
                return Page();
            }
            var adminModel = _db.AdminModel.FirstOrDefault();
            var GameBalance = TRTLService.GetTRTLBalance(adminModel.PaymentAddress);

            /*amount to withdraw would exceed balance*/
            if ((GameBalance.availableBalance) <  Input.WithdrawAmount)
            {
                TempData["ERROR"] = "Internal error 1";
                return Page();
            }

            string WithdrawAddress = Input.WithdrawAddress;
            float WithdrawalFeeDev = (5f / 100f);
            float WithdrawAmount = Input.WithdrawAmount - ((float)Input.WithdrawAmount * WithdrawalFeeDev);
            int WithdrawAmountForFeeCalculation = (int)Math.Ceiling(WithdrawAmount);
            float feeCalculated = TRTLService.GetTRTLFee(float.Parse(WithdrawAmountForFeeCalculation.ToString()));
            var transfer = TRTLService.TransferTRTL(
                from: _db.AdminModel.FirstOrDefault().PaymentAddress,
                to: WithdrawAddress,
                amount: float.Parse((WithdrawAmount + feeCalculated).ToString("n2")),
                fee: (float)0.1
            );
            if (transfer != null && transfer.transactionHash != null && transfer.transactionHash.Length > 0)
            {
                if (_db.Withdrawals.Where(w => w.transactionHash == transfer.transactionHash).FirstOrDefault() == null)
                {
                    _db.Withdrawals.Add(new Withdrawal() { transactionHash = transfer.transactionHash });
                }
                user.TRTLBalance -= Input.WithdrawAmount;
                user.TRTLWithdrawnTotal += Input.WithdrawAmount;
                _db.Users.Update(user);
                _db.SaveChanges();
                TempData["SUCCESS"] = "Withdrawal of " + WithdrawAmount + " TRTL successfull. Withdrawal hash is: " + transfer.transactionHash;
            }
            else
            {
                TempData["ERROR"] = "Internal error. Please contact admin or try different amount.";
            }
            return Page();
        }


    }
}
