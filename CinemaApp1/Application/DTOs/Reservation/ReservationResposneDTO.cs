public class ReservationResponseDTO
{
    public int Id { get; set; }
    public string UniqueCode { get; set; } = null!;
    public string MovieName { get; set; } = null!;
    public string? PosterImageUrl { get; set; }
    public DateTime ScreeningDateTime { get; set; }
    public decimal TicketPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public bool DiscountApplied { get; set; }
    public List<int> SeatNumbers { get; set; } = new();
}