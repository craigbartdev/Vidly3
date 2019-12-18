using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly3.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public CustomerDto Customer { get; set; }

        public int MovieId { get; set; }

        public MovieDto Movie { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}