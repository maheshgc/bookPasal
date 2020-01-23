using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Required]
        public int BikeNo { get; set; }
        [NotMapped]
        public IFormFile BikeImage { get; set; }
        public string ImageName { get; set; }
    }
}
