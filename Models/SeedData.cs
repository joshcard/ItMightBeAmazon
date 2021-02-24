using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItMightBeAmazon.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            BookSiteDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BookSiteDbContext>();

            //get the pending migrations and migrate them to the database
            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            //Seed the data for the database
            if(!context.Books.Any())
            {
                context.Books.AddRange(
                
                    new Book
                    {
                        Title = "Les Miserables",
                        AuthorLastName = "Hugo",
                        AuthorFirstName = "Victor",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95,
                        PageNum = 1488
                    },

                    new Book
                    {
                        Title = "Team of Rivals",
                        AuthorLastName = "Goodwin",
                        AuthorFirstName = "Doris Kearns",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fictiony",
                        Category = "Biography",
                        Price = 14.58,
                        PageNum = 944
                    },

                    new Book
                    {
                        Title = "The Snowball",
                        AuthorLastName = "Schroeder",
                        AuthorFirstName = "Alice",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54,
                        PageNum = 832
                    },

                    new Book
                    {
                        Title = "American Ulysses",
                        AuthorLastName = "White",
                        AuthorFirstName = "Ronald",
                        AuthorMiddleInitial = "C.",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 11.61,
                        PageNum = 864
                    },

                    new Book
                    {
                        Title = "Unbroken",
                        AuthorLastName = "Hillenbrand",
                        AuthorFirstName = "Laura",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 13.33,
                        PageNum = 528
                    },

                    new Book
                    {
                        Title = "The Great Train Robbery",
                        AuthorLastName = "Crichton",
                        AuthorFirstName = "Michael",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 15.95,
                        PageNum = 288
                    },

                    new Book
                    {
                        Title = "Deep Work",
                        AuthorLastName = "Newport",
                        AuthorFirstName = "Cal",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Classification = "Non-Fiction",
                        Category = "Self-help",
                        Price = 14.99,
                        PageNum = 304
                    },

                    new Book
                    {
                        Title = "It's Your Ship",
                        AuthorLastName = "Abrashoff",
                        AuthorFirstName = "Michael",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-help",
                        Price = 21.66,
                        PageNum = 240
                    },

                    new Book
                    {
                        Title = "The Virgin Way",
                        AuthorLastName = "Branson",
                        AuthorFirstName = "Richard",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        Price = 29.16,
                        PageNum = 400
                    },

                    new Book
                    {
                        Title = "Sycamore Row",
                        AuthorLastName = "Grisham",
                        AuthorFirstName = "John",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = 15.03,
                        PageNum = 642
                    },

                    new Book
                    {
                        Title = "The Way of Kings",
                        AuthorLastName = "Sanderson",
                        AuthorFirstName = "Brandon",
                        Publisher = "TOR",
                        ISBN = "978-0765326355",
                        Classification = "Fiction",
                        Category = "Fantasy",
                        Price = 23.64,
                        PageNum = 1007
                    },

                    new Book
                    {
                        Title = "Mistborn: The Final Empire",
                        AuthorLastName = "Sanderson",
                        AuthorFirstName = "Brandon",
                        Publisher = "TOR",
                        ISBN = "978-0765311788",
                        Classification = "Fiction",
                        Category = "Fantasy",
                        Price = 24.44,
                        PageNum = 541
                    },

                    new Book
                    {
                        Title = "Oathbringer",
                        AuthorLastName = "Sanderson",
                        AuthorFirstName = "Brandon",
                        Publisher = "TOR",
                        ISBN = "978-0765326379",
                        Classification = "Fiction",
                        Category = "Fantasy",
                        Price = 23.26,
                        PageNum = 1248
                    }

                );

                //save the changes to the database
                context.SaveChanges();
            }
        }
    }
}
