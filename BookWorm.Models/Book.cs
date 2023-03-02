using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int AuthorId { get; set; }
        [ValidateNever]
        public Author Author { get; set; }
        public int GenreId { get; set; }
        [ValidateNever]
        public Genre Genre { get; set; }
        public string publisher { get; set; }
        [ValidateNever]
        public string cover_image { get; set; }

        [ValidateNever]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm tt}")]
        public DateTime publication_date { get; set; }
        public string isbn { get; set; }
     



    }
}
