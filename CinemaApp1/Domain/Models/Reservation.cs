using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Domain.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public string ConfirmationCode { get; set; }
        public string UserId { get; set; }
        public int MovieScreeningId { get; set; }
        public string ReservationName { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TotalPrice { get; set; }
        public bool Status { get; set; }

        // Foreign keys
        public ApplicationUser User { get; set; }
        public MovieScreening MovieScreening { get; set; }

        //N:N
        public ICollection<ReservationSeat> ReservationSeats { get; set; } = new List<ReservationSeat>();
    }
}
