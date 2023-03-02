using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set;}

        [ValidateNever]
        public string imageUrl { get; set; }

    }
}
