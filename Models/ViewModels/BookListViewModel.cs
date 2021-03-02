using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItMightBeAmazon.Models.ViewModels
{
    //this is the class that will be passed into views
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }
    }
}
