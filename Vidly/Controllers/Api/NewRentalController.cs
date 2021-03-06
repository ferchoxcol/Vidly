﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalController:ApiController
    {
        private ApplicationDbContext _context= new ApplicationDbContext();

        public NewRentalController()
        {
            _context= new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        public IHttpActionResult NewRental(NewRentalDto newRental)
        {
            
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);

            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();
            
            
            foreach (var movie in movies)
            {
                if (movie.NumberAvailable==0)
                {
                    BadRequest("movie "+ movie.Name +" is not availeable in this moment.");
                }
                movie.NumberAvailable --;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();

            return Ok();
        }
    }
}