using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TRTLFarm.Models
{
    public class SpecialAnimal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductionSpeed { get; set; }
        public int ProductionTimeSeconds { get; set; }
        public string ProductionUnit { get; set; }
        public string ProduceImage { get; set; }
        public string ProduceName { get; set; }
        /*at what version price/production goes up example 10 means every 10 versions/steals */
        public int IncrementVersion { get; set; }
        public int Version { get; set; }
        public int ProductionPercentageIncrease { get; set; }
        public int PricePercentageIncrease { get; set; }
        public int CooldownSeconds { get; set; }
        public DateTime LastBoughtTime { get; set; }
        public string OwnerUserId { get; set; }
        public DateTime ManualLastClaimDate { get; set; }
    }
}
