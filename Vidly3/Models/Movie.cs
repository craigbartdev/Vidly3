using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly3.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in Stock")]
        public byte NumberInStock { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genres")]
        [Required]
        public byte GenreId { get; set; }
    }
    //uses movies/random route called from MoviesController
}