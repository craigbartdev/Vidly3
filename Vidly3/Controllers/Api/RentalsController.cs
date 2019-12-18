using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly3.Dtos;
using Vidly3.Models;
using AutoMapper;

namespace Vidly3.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/rentals
        [HttpGet]
        public IHttpActionResult GetRentals()
        {
            //only get rentals that have not been returned
            //need to import entity to use Include
            var rentalDtos = _context.Rentals.
                Include(c => c.Customer).Include(m => m.Movie).
                ToList().Select(Mapper.Map<Rental, RentalDto>);

            return Ok(rentalDtos);
        }

        //GET /api/ActiveRentals
        [HttpGet]
        [Route("api/ActiveRentals")]
        public IHttpActionResult GetActiveRentals()
        {
            //only get rentals that have not been returned
            //need to import entity to use Include
            var rentalDtos = _context.Rentals.Where(r => r.DateReturned == null).
                Include(c => c.Customer).Include(m => m.Movie).
                ToList().Select(Mapper.Map<Rental, RentalDto>);

            return Ok(rentalDtos);
        }

        //PUT /api/rentals/id
        //all we need to do is set date returned and number available to return a rental
        //view has a data table that takes the list of RentalDtos above
        //ReturnRentalDto only includes rental id and movie id to simplify the AJAX request
        //was a pain loading the entire movie and customer objects which we did not need to send back
        [HttpPut]
        public IHttpActionResult UpdateRental(int id, ReturnRentalDto rentalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(rentalDto.ToString());

            //picking rental from rentals list so just use Single
            var movie = _context.Movies.Single(m => m.Id == rentalDto.MovieId);

            if (movie == null)
                return NotFound();

            //picking rental from rentals list so just use Single
            var rentalInDb = _context.Rentals.Single(r => r.Id == id);

            if (rentalInDb == null)
                return NotFound();

            //only set the things that we need to set
            movie.NumberAvailable++;
            rentalInDb.DateReturned = DateTime.Now;

            _context.SaveChanges();

            return Ok();
        }

        //POST /api/NewRental
        [HttpPost]
        [Route("api/NewRental")]
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

                //instead of using automapper we manually map the dto to the rental
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
