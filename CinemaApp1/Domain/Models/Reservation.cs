using CinemaApp.Domain.Models;

public class Reservation
{
    public int Id { get; set; }
    public int? UserId { get; set; }       
    public string? GuestEmail { get; set; }  
    public int ScreeningId { get; set; }
    public string UniqueCode { get; set; } = null!;
    public decimal TotalPrice { get; set; }
    public bool DiscountApplied { get; set; }
    public bool IsCanceled { get; set; }
    public DateTime CreatedAt { get; set; }


    public User? User { get; set; }
    public MovieScreening Screening { get; set; } = null!;
    public ICollection<Seat> Seats { get; set; } = new List<Seat>();
    public Rating? Rating { get; set; }
}