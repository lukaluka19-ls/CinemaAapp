using System.ComponentModel.DataAnnotations;

namespace CinemaApp1.Application.DTOs.Genre
{
    public class GenreResponseDTO
    {
        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
