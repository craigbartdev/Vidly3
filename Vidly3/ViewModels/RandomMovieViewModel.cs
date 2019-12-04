using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly3.Models;

//viewModels are for specific views and actions
namespace Vidly3.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}