using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TRTLFarm.Models
{
    public class UserAnimals
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int AnimalId { get; set; }

        [ForeignKey("AnimalId")]
        public Animal Animal { get; set; }
        [Required]
        public int AnimalCount { get; set; }
        [Required]
        public DateTime LastClaimTime { get; set; }
        public int ClaimedProduceCount { get; set; }
    }
}
