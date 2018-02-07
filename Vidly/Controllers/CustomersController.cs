using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Details(int id)
        {

            Customer customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c=> c.Id == id);

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
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes  =membershipTypes
            };


            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            ;
            if (customer.Id==0)
            {
            _context.Customers.Add(customer);
            
            }
            else
            {
              
                var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);
              
                customerInDB.Name = customer.Name;
                customerInDB.BirthDate = customer.BirthDate;
                customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
            }

            _context.SaveChanges(); 
           return  RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Single(c => c.Id == id);

            if (customer== null)
            return  HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer
                ,MembershipTypes = _context.MembershipTypes.ToList()

            };
            return View("CustomerForm",viewModel);
        }

        

    }


}