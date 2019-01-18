using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRTLFarm.Services.ServiceModels
{
    public class AddressBalance
    {
        public decimal availableBalance { get; set; }
        public decimal lockedBalance { get; set; }
        public string blockIndex { get; set; }
    }
}
