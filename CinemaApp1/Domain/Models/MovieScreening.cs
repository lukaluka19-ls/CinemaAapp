using CinemaApp.Domain.Models;

public class MovieScreening
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public DateTime DateTime { get; set; }
    public decimal TicketPrice { get; set; }
    public int TotalSeats { get; set; }

    // navigaciona svojstva
    public Movie Movie { get; set; } = null!;
    public ICollection<Seat> Seats { get; set; } = new List<Seat>();
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}