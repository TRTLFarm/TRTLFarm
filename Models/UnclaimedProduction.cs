using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRTLFarm.Models
{
    public class UnclaimedProduction
    {
        public decimal prodFromLastClaim { get; set; }
        public decimal perSecond { get; set; }
        public string UserId { get; set; }
        public int AnimalId { get; set; }
        public int AnimalCount { get; set; }
        public DateTime LastClaimTime { get; set; }
        public decimal ProductionSpeed { get; set; }
        public int ProductionTimeSeconds { get; set; }
        public string TRTLPaymentId { get; set; }
        public string Nickname { get; set; }
        public int UnclaimedId { get; set; }
        public int SafeZone { get; set; }
    }
}
