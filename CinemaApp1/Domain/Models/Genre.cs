using CinemaApp.Domain.Models;
using System.ComponentModel.DataAnnotations;

public class Genre
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<Movie> Movies { get; set; } = new List<Movie>();
}