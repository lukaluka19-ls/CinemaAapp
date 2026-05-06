using System.ComponentModel.DataAnnotations;

namespace CinemaApp1.Application.DTOs.Reservation
{
    public class CreateReservationDTO
    {
        [Required(ErrorMessage = "Screening is required!")]
        public int ScreeningId { get; set; }

        [Required(ErrorMessage = "Seat is required!")]
        public int SeatId { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format!")]
        public string? GuestEmail { get; set; }

    }
}
