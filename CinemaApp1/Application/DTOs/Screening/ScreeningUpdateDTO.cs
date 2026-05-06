using System.ComponentModel.DataAnnotations;

namespace CinemaApp1.Application.DTOs.Screening
{
    public class ScreeningUpdateDTO
    {
        [Required(ErrorMessage = "Starting time of the screening is required!")]
        public DateTime DateTime { get; set; }

        [Range(0.01, 10000, ErrorMessage = "Ticket price must be greater than 0!")]
        public decimal TicketPrice { get; set; }

    }
}
