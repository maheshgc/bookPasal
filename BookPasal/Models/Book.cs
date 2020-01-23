using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookPasal.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string FileName { get; set; }
        [NotMapped]
        public IFormFile UploadImage { get; set; }
    }
}
