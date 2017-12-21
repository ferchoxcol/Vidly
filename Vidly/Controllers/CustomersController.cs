using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            
            return View(GetCustomers());
        }

        public ActionResult Details(int id)
        {

            Customer customer = GetCustomers().SingleOrDefault(c=> c.Id == id);

            if (customer== null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer {Id = '1', Name = "Fernando Borja"},
                new Customer {Id = '2', Name = "Sandra Pineda"}
            };
        }
    }


}