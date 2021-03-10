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
        public PurchaseModel(IBookRepository repo)
        {
            repository = repo;
        }

        //Properties of the class
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        //Methods
        //Get method
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        //Post method
        public IActionResult OnPost(long bookId, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(p => p.BookId == bookId);

            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(book, 1);

            HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
