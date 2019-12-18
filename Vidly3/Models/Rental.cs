using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly3.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }

        //need foreign key for the Return view and api actions
        public int CustomerId { get; set; }

        [Required]
        public Movie Movie { get; set; }

        //need foreign key for the Return view and api actions
        public int MovieId { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}