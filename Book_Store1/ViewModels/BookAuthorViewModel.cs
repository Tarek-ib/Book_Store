using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store1.Models
{
    public class BookAuthorViewModel
    {
        public int BookId { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5)]
        public string Descrebtion { get; set; }
        public string FullName  { get; set; }
        public int AuthorId { get; set; }
        public string ImgUrl { get; set; }

        public IFormFile MyFile { get; set; }
        public List<Author> Authors { get; set; }
    }
}
