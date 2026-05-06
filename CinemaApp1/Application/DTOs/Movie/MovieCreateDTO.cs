using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CinemaApp1.Application.DTOs.Movie
{
    public class MovieCreateDTO
    {
        [Required(ErrorMessage = "Name of the movie is required")]
        [MaxLength(40, ErrorMessage = "Name of the movie cannot be longer than 50 characters")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Original title of the movie is required")]
        [MaxLength(200)]
        public string OriginalTitle { get; set; } = string.Empty;

        [Range(1,600, ErrorMessage = "Movie lenght must be les then 600 and more then 1 min")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Genre of the movie is required")]
        public int GenreId { get; set; }

        public IFormFile? Poster { get; set; }


    }
}
