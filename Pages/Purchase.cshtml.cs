using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItMightBeAmazon.Infrastructure;
using ItMightBeAmazon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItMightBeAmazon.Pages
{
    public class PurchaseModel : PageModel
    {
        private IBookRepository repository;

        //Constructor
        public PurchaseModel(IBookRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        //Properties of the class
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        //Methods
        //Get method
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        //Post method
        public IActionResult OnPost(long bookId, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(p => p.BookId == bookId);

            Cart.AddItem(book, 1);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        //method for removing an item from the cart
        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
                cl.Book.BookId == bookId).Book);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
