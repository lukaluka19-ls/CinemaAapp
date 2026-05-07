using System.ComponentModel.DataAnnotations;

public class MovieUpdateDTO
{
    [MaxLength(200)]
    public string? Name { get; set; }
    [MaxLength(200)]
    public string? OriginalName { get; set; }
    [Range(1, 500)]
    public int? Duration { get; set; }
    public IFormFile? PosterImage { get; set; }
    public int? GenreId { get; set; }
}