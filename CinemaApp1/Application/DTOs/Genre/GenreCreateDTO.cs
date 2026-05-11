using System.ComponentModel.DataAnnotations;

public class GenreCreateDTO
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;
}