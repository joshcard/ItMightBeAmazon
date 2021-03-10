using ItMightBeAmazon.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItMightBeAmazon.Components
{
    //this component will be used to display the categories for filtering
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBookRepository repository;

        //Constructor for the class setting repository equal to the parameter repo
        public NavigationMenuViewComponent(IBookRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            //ViewBag for the selected category
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            //create partial view to be returned
            return View(repository.Books
                .Select(x => x.Category)
                //make sure we don't see duplicate categories
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
