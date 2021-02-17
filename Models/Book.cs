﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ItMightBeAmazon.Models
{
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

        [Required]
        public string Publisher { get; set; }

        [Required]
        [RegularExpression(@"\d{3}-?\d{10}", ErrorMessage = "ISBN entered incorrectly, please use this format: 000-0000000000")]
        public string ISBN { get; set; }

        [Required]
        public string Classification { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
