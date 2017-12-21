using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() {Name="Shrek!"};

            var viewResult = new ViewResult();

            List<Customer> customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"},
                new Customer {Name = "Customer 3"},
                new Customer {Name = "Customer 4"},
                new Customer {Name = "Customer 5"},
                new Customer {Name = "Customer 6"},
            };

            var viewModel = new RandomMovieViewModel();

            viewModel.Movie = movie;
            viewModel.Customers = customers;



            
            return View(viewModel);
            //return View(movie);
            //return Content("Hello World!!");
            //return HttpNotFound();
            //return new EmptyResult();
            // return RedirectToAction("Index", "Home", new {page = "1", sortby = "Name"});
        }

        public ActionResult Edit(int id)
        {
            return Content("Id=" + id);
        }

        public ActionResult Index (int? pageIndex, String sortBy)
        {

            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content(String.Format("pageIndex={0} & sortBy={1}", pageIndex, sortBy));

        }
        [Route("Movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleasedYear(int year, int month)
        {
            return Content(year +"/"+month);
        }
    }
}