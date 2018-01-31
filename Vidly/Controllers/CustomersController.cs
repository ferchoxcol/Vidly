﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
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
            
            return View(_context.Customers.Include(c => c.MembershipType).ToList());
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
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes  =membershipTypes
            };


            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
           return  RedirectToAction("Index", "Customers");
        }
    }


}