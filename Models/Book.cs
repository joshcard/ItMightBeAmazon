using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ItMightBeAmazon.Models
{
    //model for Books with a primary key, and all fields required except for the author's middle initial.
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string AuthorLastName { get; set; }

        [Required]
        public string AuthorFirstName { get; set; }

        public string AuthorMiddleInitial { get; set; }

        [Required]
        public string Publisher { get; set; }

        //Regex to ensure that the ISBN is entered in the correct format.
        [Required]
        [RegularExpression(@"\d{3}-\d{10}", ErrorMessage = "ISBN entered incorrectly, please use this format: 000-0000000000")]
        public string ISBN { get; set; }

        [Required]
        public string Classification { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
