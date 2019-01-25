using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TRTLFarm.Models;

namespace TRTLFarm.ViewModels
{
    public class LeaderBoardModel
    {
        public string CurrentUserPaymentId { get; set; }
        public int CurrentUserPosition { get; set; }
        public IEnumerable<LeaderBoard> leaderBoard { get; set; }
        public List<SpecialAnimal> SpecialAnimals { get; set; }

        [Required]
        [Display(Name = "Your new nickname")]
        public string NewNickname { get; set; }
    }

    public class LeaderBoard
    {
        public string PaymentId { get; set; }
        public decimal SumProdSpeed { get; set; }
        public string NickName { get; set; }
        public string UserId { get; set; }
    }
}
