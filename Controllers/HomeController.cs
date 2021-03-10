using ItMightBeAmazon.Models;
using ItMightBeAmazon.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ItMightBeAmazon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //create a private variable _repository
        private IBookRepository _repository;

        //PageSize to specify how many books there should be per page
        public int PageSize = 5;

        //grab the object from the IBookRepository and save it to _repository
        public HomeController(ILogger<HomeController> logger, IBookRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        //pass the books from _repository to the view
        //pass a parameter for page, if nothing is passed use 1
        public IActionResult Index(string category, int pageNum = 1)
        {
            return View(new BookListViewModel
            {
                //Linq statement grabing the book info for pagination
                Books = _repository.Books
                    //filter the books by category
                    .Where(b => category == null || b.Category == category)
                    .OrderBy(p => p.BookId)
                    .Skip((pageNum - 1) * PageSize)
                    .Take(PageSize)
                ,
                //PagingInfo passed in for pagination
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = PageSize,
                    //ensure that the correct number of pages is displayed depending on if there has been any filtering by category
                    TotalNumItems = category == null ? _repository.Books.Count() : _repository.Books.Where(x => x.Category == category).Count()
                }
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
