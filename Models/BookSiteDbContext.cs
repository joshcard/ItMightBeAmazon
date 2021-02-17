using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItMightBeAmazon.Models
{
    public class BookSiteDbContext : DbContext
    {
        public BookSiteDbContext (DbContextOptions<BookSiteDbContext> options) : base (options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
