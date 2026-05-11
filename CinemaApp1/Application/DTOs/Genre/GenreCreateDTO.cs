using System.ComponentModel.DataAnnotations;

public class GenreCreateDTO
{
    [Required]
    public int id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;
}