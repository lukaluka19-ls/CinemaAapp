public class ScreeningListDTO
{
    public int Id { get; set; }
    public string MovieName { get; set; } = null!;
    public string? PosterImageUrl { get; set; }
    public string GenreName { get; set; } = null!;
    public DateTime DateTime { get; set; }
    public decimal TicketPrice { get; set; }
    public int AvailableSeats { get; set; }
    public bool IsPast { get; set; }
    public double? AverageRating { get; set; }
}