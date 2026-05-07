using CinemaApp.Domain.Models;

public class Movie
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string OriginalName { get; set; } = null!;
    public int Duration { get; set; }
    public string? PosterImage { get; set; }  // path ili URL do slike
    public int GenreId { get; set; }

    // navigaciona svojstva
    public Genre Genre { get; set; } = null!;
    public ICollection<MovieScreening> Screenings { get; set; } = new List<MovieScreening>();
    public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}