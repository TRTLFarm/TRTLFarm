using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TRTLFarm.Models
{
    public class Animal
    {
        public Animal()
        {
           
        }
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductionSpeed { get; set; }
        public int ProductionTimeSeconds { get; set; }
        public string ProductionUnit { get; set; }
        //public virtual ICollection<UserAnimals> UserAnimals { get; set; }
        public string ProduceImage { get; set; }
        public string ProduceName { get; set; }
        [NotMapped]
        public int Quantity { get; set; }
    }
}
