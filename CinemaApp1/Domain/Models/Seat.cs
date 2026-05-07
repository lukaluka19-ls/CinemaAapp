using CinemaApp.Domain.Models;

public class Seat
{
    public int Id { get; set; }
    public int ScreeningId { get; set; }
    public int SeatNumber { get; set; }
    public bool IsOccupied { get; set; }

    // navigaciona svojstva
    public MovieScreening Screening { get; set; } = null!;
    public ICollection<ReservationSeat> ReservationSeats { get; set; } = new List<ReservationSeat>();
}