using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class NewRental : ApiController
    {
        private ApplicationDbContext _context;
        public NewRental()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult MovieRental(MovieRentalDto movieRentalDto)
        {
            var cutomer = _context.Customer.Single(x => x.Id == movieRentalDto.CustomerId);
            var movies = _context.Movie.Where(x => movieRentalDto.MovieId.Contains(x.Id));

            foreach (var item in movies)
            {
                item.MoviesLeft--;
                var rental = new Rental
                {
                    Customer = cutomer,
                    Movie = item,
                    DateRented = DateTime.Now
                };

                _context.Rental.Add(rental);

            }
            _context.SaveChanges();

            return Ok();
        }

    }
}