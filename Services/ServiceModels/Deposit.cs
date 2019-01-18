using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TRTLFarm.Services.ServiceModels
{
    public class Deposit
    {
        public int Id { get; set; }
        public string address { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal amount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal fee { get; set; }
        public string transactionHash { get; set; }
        public string blockHash { get; set; }
        public string paymentId { get; set; }
        public string extra { get; set; }
        public long timestamp { get; set; }
        public int blockIndex { get; set; }
        public int confirms { get; set; }
        public bool AddedToBalance { get; set; }
    }
}
