using System.ComponentModel.DataAnnotations;

public class MovieCreateDTO
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } 
    [Required]
    [MaxLength(200)]
    public string OriginalName { get; set; }
    [Required]
    [Range(1, 500)]
    public int Duration { get; set; }
    public IFormFile? PosterImage { get; set; }
    [Required]
    public int GenreId { get; set; }
}