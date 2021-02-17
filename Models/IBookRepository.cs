using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItMightBeAmazon.Models
{
    //Interface to set up the template. 
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
