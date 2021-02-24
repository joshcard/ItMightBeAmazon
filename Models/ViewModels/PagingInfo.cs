using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItMightBeAmazon.Models.ViewModels
{
    //class for paging info
    public class PagingInfo
    {
        public int TotalNumItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        //Calculate the number of pages we should have based on the number of items in the database and the items per page
        public int TotalPages => (int)(Math.Ceiling((decimal)TotalNumItems / ItemsPerPage));
    }
}
