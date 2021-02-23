using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItMightBeAmazon.Models
{
    //EFBookRepository inherits from IBookRepository
    public class EFBookRepository : IBookRepository
    {
        private BookSiteDbContext _context;

        //Constructor
        public EFBookRepository (BookSiteDbContext context)
        {
            _context = context;
        }

        //creates the IQueryable to be used in the view
        public IQueryable<Book> Books => _context.Books; 
    }
}
