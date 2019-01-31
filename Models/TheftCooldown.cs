using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRTLFarm.Models
{
    public class TheftCooldown
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime LastUserAttack { get; set; }
        public DateTime LastBeenAtacked { get; set; }
        public int TotalStealCount { get; set; }
    }
}
