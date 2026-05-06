using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Domain.Models
{
    public class ReservationSeat
    {
        [Key]
        public int Id { get; set; }
        public string ReservationId { get; set; }
        public int SeatId { get; set; }

        public Reservation Reservation { get; set; }
        public Seat Seat { get; set; }
    }
}
