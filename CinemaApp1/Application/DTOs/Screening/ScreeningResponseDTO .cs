public class ScreeningResponseDTO
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public string MovieName { get; set; } = null!;
    public string? PosterImageUrl { get; set; }
    public string GenreName { get; set; } = null!;
    public DateTime DateTime { get; set; }
    public decimal TicketPrice { get; set; }
    public int TotalSeats { get; set; }
    public int AvailableSeats { get; set; }
    public double? AverageRating { get; set; }
}