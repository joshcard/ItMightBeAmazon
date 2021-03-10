using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItMightBeAmazon.Models
{
    public class Cart
    {
        //property List of CartLine objects called Lines
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        //AddItem method
        public void AddItem (Book book, int qty)
        {
            CartLine line = Lines
                .Where(p => p.Book.BookId == book.BookId)
                .FirstOrDefault();

            //if statement to see if the line is null. if it is then a new CartLine is added to the Lines List
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        //Method to remove a line from Lines
        public void RemoveLine(Book book) =>
            Lines.RemoveAll(x => x.Book.BookId == book.BookId);

        //method to clear all from Lines
        public void Clear() => Lines.Clear();

        //Method to compute total sum
        public decimal ComputeTotalSum() => (decimal)Lines.Sum(e => e.Book.Price * e.Quantity);

        //class Cartline so that the Book and Quantity can be accessed at the same place
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}
