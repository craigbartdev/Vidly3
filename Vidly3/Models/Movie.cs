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

        [Required]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1,20)]
        public byte NumberInStock { get; set; }

        [Range(1, 20)]
        public byte NumberAvailable { get; set; } //bytes are required automatically

        public Genre Genre { get; set; }

        [Display(Name = "Genres")]
        [Required]
        public byte GenreId { get; set; }
    }
    //uses movies/random route called from MoviesController
}