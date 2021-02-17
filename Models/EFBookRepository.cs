using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItMightBeAmazon.Models
{
    public class EFBookRepository : IBookRepository
    {
        private BookSiteDbContext _context;

        //Constructor
        public EFBookRepository (BookSiteDbContext context)
        {
            _context = context;
        }

        public IQueryable<Book> Books => _context.Books;
    }
}
