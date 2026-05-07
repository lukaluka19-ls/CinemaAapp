public class MovieResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string OriginalName { get; set; } = null!;
    public int Duration { get; set; }
    public string? PosterImageUrl { get; set; }
    public int GenreId { get; set; }
    public string GenreName { get; set; } = null!;
    public double? AverageRating { get; set; }
}