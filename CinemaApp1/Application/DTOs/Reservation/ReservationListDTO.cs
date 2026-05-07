public class ReservationListDTO
{
    public int Id { get; set; }
    public string UniqueCode { get; set; } = null!;
    public string MovieName { get; set; } = null!;
    public string? PosterImageUrl { get; set; }
    public DateTime ScreeningDateTime { get; set; }
    public decimal TotalPrice { get; set; }
    public bool DiscountApplied { get; set; }
    public bool IsPast { get; set; }
    public bool IsCanceled { get; set; }
    public int? Rating { get; set; }  // null ako nije ocenjeno
}