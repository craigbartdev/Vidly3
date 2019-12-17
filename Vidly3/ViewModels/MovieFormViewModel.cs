using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using Vidly3.Models;

namespace Vidly3.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        //show individual values instead of Movie since loading weird defaults into New Movie form inputs
        //public Movie Movie { get; set; }

        //make nullible to prevent weird defaults. only for stuff in form fields
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public byte? NumberInStock { get; set; }

        //started getting modelstate errors without this so add this
        //must include because it is required in the model
        public byte? NumberAvailable { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        //conditionally render title
        public string Title
        {
            get
            {
                ////commented out Movie above so use Id instead
                //if (Movie != null && Movie.Id != 0)
                //    return "Edit Movie";

                //return "New Movie";
                return Id != 0 ? "Edit Movie" : "Add Movie";
            }
        }

        //constructors because we got rid of the Movie above. Now need this in action
        //these are hidden fields in the form view
        public MovieFormViewModel() //for new movie action
        {
            Id = 0;
            NumberAvailable = 0; //initialize here then set in Save action
        }

        //pass this movie into MovieFormViewModel in actions
        public MovieFormViewModel(Movie movie) //for edit and save
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            NumberAvailable = movie.NumberAvailable;
            GenreId = movie.GenreId;
        }
    }
}