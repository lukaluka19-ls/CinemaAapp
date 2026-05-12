using CinemaApp.Domain.Models;

public class Seat
{
    public int Id { get; set; }
    public int ScreeningId { get; set; }
    public int SeatNumber { get; set; }
    public bool IsOccupied { get; set; }

    // navigaciona svojstva
    public MovieScreening Screening { get; set; } = null!;
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public bool IsOccupiedCheck()
        => Reservations.Any(r => !r.IsCanceled);
}