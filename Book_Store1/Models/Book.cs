using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store1.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15,MinimumLength =5)]
        public String Title { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 5)]
        public string Describtion { get; set; }
        public string  My_ImageUrl { get; set; }
        public Author Author { get; set; }
    }
}
