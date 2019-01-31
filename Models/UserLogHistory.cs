using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRTLFarm.Models
{
    public class UserLogHistory
    {
        public int Id { get; set; }
        public string LogType { get; set; }
        public string UserId { get; set; }
        public string LogMessage { get; set; }
        public DateTime Date { get; set; }
        public string Action { get; set; }
    }
}
