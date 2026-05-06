using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Domain.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public int MovieScreeningId { get; set; }       
        public string Row { get; set; }
        public string SeatNumber { get; set; }

        public bool IsReserved { get; set; } = false;

        public MovieScreening MovieScreening { get; set; }

        // N:N relationship with Reservation through ReservationSeat
        public ICollection<ReservationSeat> ReservationSeats { get; set; } = new List<ReservationSeat>();
    }
}
