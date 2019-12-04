using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly3.Models;

namespace Vidly3.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }

        //conditionally render title
        public string Title
        {
            get
            {
                if (Movie != null && Movie.Id != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }
    }
}