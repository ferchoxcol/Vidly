using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController:ApiController
    {

        private ApplicationDbContext _context ;

        public MoviesController()
        {
            _context= new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Get /api/Movies/
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.Include(m => m.Genre).ToList();
        }

        //Get by id /api/Movies/id
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.Single(m => m.Id == id);

            if (movie == null)
            {
                NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movie));

        }


        //Post /api/Movies/
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageCustomers)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);

            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageCustomers)]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
              throw new   HttpResponseException(HttpStatusCode.BadRequest);
            }

            var movieInDb = _context.Movies.Single(m => m.Id == id);

            if (movieInDb== null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(movieDto, movieInDb);
            
            _context.SaveChanges();



        }

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageCustomers)]
        public void DeleteMovie(int id)
        {
            var MovieInDb = _context.Movies.Single(m => m.Id == id);

            if (MovieInDb== null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Movies.Remove(MovieInDb);
            _context.SaveChanges();
        }
    }
}