using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRTLFarm.Models;

namespace TRTLFarm.ViewModels
{
    public class SellModel
    {
        public SellModel()
        {
            OwnedAnimals = new List<UserAnimals>();
        }
        public List<UserAnimals> OwnedAnimals { get; set; }
        public decimal UnitPrice { get; set; }
    }




}
