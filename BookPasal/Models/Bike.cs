using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookPasal.Models
{
    public class Bike
    { 
        [Key]
        public int BikeId { get; set; }
        [Required]
        public string BikeName { get; set; }
        public string BikeModel { get; set; }
        public int BikeNo { get; set; }
    }
}
