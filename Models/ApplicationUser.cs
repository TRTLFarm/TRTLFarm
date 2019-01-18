using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TRTLFarm.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TRTLBalance { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TRTLDepositedTotal { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TRTLWithdrawnTotal { get; set; }
        public string TRTLPaymentId { get; set; }
        public string RefCode { get; set; }
        public string RefCodeUsed { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal RefRewards { get; set; }
    }
}
