using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TRTLFarm.ViewModels
{
    public class AdminModel
    {
        public int Id { get; set; }
        public string PaymentAddress { get; set; }
        [NotMapped]
        public decimal Balance { get; set; }

    }
}
