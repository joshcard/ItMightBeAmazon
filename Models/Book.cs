using System;
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
        [RegularExpression("^(?:ISBN(?:-1[03])?:?●)?(?=[0-9X]{10}$|(?=(?:[0-9]+[-●]){3})[-●0 - 9X]{13}$|97[89] [0-9]{10}$| (?= (?:[0 - 9] +[-●]){ 4})[-●0-9]{ 17}$)(?: 97[89][-●] ?)?[0 - 9]{ 1,5}[-●]?[0 - 9] +[-●]?[0 - 9] +[-●]?[0 - 9X]$")]
        public string ISBN { get; set; }

        [Required]
        public string Classification { get; set; }

        [Required]
        public float Price { get; set; }
    }
}
