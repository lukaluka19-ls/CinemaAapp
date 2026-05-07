using CinemaApp.Domain.Models;

public class ReservationSeat
{
    public int Id { get; set; }
    public int ReservationId { get; set; }
    public int SeatId { get; set; }

    // navigaciona svojstva
    public Reservation Reservation { get; set; } = null!;
    public Seat Seat { get; set; } = null!;
}