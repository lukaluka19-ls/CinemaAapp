
using System.ComponentModel.DataAnnotations;

public class GenreUpdateDTO
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;
}