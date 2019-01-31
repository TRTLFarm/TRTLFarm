using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRTLFarm.Models;

namespace TRTLFarm.ViewModels
{
    public class TheftIndexModel
    {
        public TheftIndexModel()
        {
            UnclaimedProductions = new List<UnclaimedProduction>();
        }
        public int YourHourlyStealPower { get; set; }
        public List<UnclaimedProduction> UnclaimedProductions { get; set; }
        public int SecondsCooldown { get; set; }
    }
}
