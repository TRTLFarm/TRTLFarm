using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRTLFarm.Services.ServiceModels
{
    public class TransferTRTL
    {
        public string from { get; set; }
        public string to { get; set; }
        public float amount { get; set; }
        public float fee { get; set; }
    }
}
