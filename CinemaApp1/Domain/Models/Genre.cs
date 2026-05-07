using CinemaApp.Domain.Models;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    // navigaciona svojstva
    public ICollection<Movie> Movies { get; set; } = new List<Movie>();
}