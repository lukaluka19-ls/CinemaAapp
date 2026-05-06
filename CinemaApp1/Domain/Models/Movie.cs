using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Domain.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        public string GenreId { get; set; }
        public int MovieDuration { get; set; }
        public double AverageRating { get; set; }
        public string OriginalTitle { get; set; }


        //Key za genere jer ima many movies
        public Genre Genre { get; set; }

        public ICollection<MovieScreening> MovieScreenings { get; set; } = new List<MovieScreening>();
    }
}