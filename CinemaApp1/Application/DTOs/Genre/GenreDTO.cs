using System.ComponentModel.DataAnnotations;

namespace CinemaApp1.Application.DTOs.Genre
{
    public class GenreDTO
    {
        [Required(ErrorMessage = "Name of genre is required!")]
        [MaxLength(20, ErrorMessage = "Genre can't be more than 20 characters")]
        public string Name { get; set; } = string.Empty;
    }
}
