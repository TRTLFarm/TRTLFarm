using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRTLFarm.Models;

namespace TRTLFarm.ViewModels
{
    public class HomeModel
    {
        public HomeModel()
        {
            OwnedAnimals = new List<UserAnimals>();
        }
        public List<UserAnimals> OwnedAnimals { get; set; }
        public int ActivePlayers { get; set; }
    }
}
