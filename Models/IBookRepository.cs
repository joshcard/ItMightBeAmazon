using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItMightBeAmazon.Models
{
    public class IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
