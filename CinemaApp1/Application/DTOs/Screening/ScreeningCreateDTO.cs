using System.ComponentModel.DataAnnotations;

namespace CinemaApp1.Application.DTOs.Screening
{
    public class ScreeningCreateDTO
    {
        [Required(ErrorMessage = "Title of the screening is required!")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Starting time of the screening is required!")]
        public DateTime StartingTime { get; set; }

        [Required(ErrorMessage = "Ending time of the screening is required!")]
        public DateTime EndingTime { get; set; }

        [Required(ErrorMessage = "Ticket price of the screening is required!")]
        [Range(0.01,10000,ErrorMessage = "Ticket price must be greater than 0!")]
        public decimal TicketPrice { get; set; }

        [Range(1,500,ErrorMessage = "Total seats must be between 1 and 500!")]
        public int TotalSeats { get; set; }

    }
}
