using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TRTLFarm.Services.ServiceModels
{
    public class Withdrawal
    {
        public int Id { get; set; }
        public string addressTo { get; set; }
        public string addressFrom { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal amount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal fee { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal sfee { get; set; }
        public string transactionHash { get; set; }
        public long timestamp { get; set; }
        public int blockIndex { get; set; }
        public int confirms { get; set; }
    }
}
