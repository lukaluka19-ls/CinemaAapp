using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Domain.Models
{
    public class MovieScreening
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime EndingTime { get; set; }
        public TimeSpan Duration => EndingTime - StartingTime;
        public Movie Movie { get; set; }
        public decimal TicketPrice { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public ICollection<Seat> Seats { get; set; } = new List<Seat>();
    }
}
