using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly3.Dtos;
using Vidly3.Models;

namespace Vidly3.Controllers.Api
{
    public class NewRentalController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }

        //POST /api/NewRental
        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRental)
        {
            ////defensive approach
            ////handle edge case where no movieids have been given by dto
            //if (newRental.MovieIds.Count == 0)
            //    BadRequest("No MovieIds have been given");

            //Optimistic approach to edge cases
            //get customer where id is same as dto id
            //Single without default because we assume the id is picked from a list
            var customer = _context.Customers.Single(
                c => c.Id == newRental.CustomerId);

            ////defensive approach to edge cases
            //var customer = _context.Customers.SingleOrDefault(
            //    c => c.Id == newRental.CustomerId);

            //if (customer == null)
            //    BadRequest("CustomerId is not valid");

            //goes through movies in db and if the id is in the movieid list in dto it adds it to variable
            var movies = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id)).ToList(); //list not Iqueryable

            ////defensive approach
            ////validate movies before adding Rental to DB
            //if (movies.Count != newRental.MovieIds.Count)
            //    return BadRequest("One or more MovieIds are invalid.");

            foreach (var movie in movies)
            {
                //check if movie is available. good for both optimistic and defensive cases
                //prevents this variable from going negative
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");

                //if available decrement NumberAvailable since it is initially set to NumberInStock
                movie.NumberAvailable--;

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
