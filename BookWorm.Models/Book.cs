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
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        [ValidateNever]
        public string BookCover { get; set; }

        [ValidateNever]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm tt}")]
        public DateTime Publication_date { get; set; }
        public string ISBN { get; set; }
        public int GenreId { get; set; }
        [ValidateNever]
        public Genre Genre { get; set; }



    }
}
