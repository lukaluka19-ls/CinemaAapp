using CinemaApp.Domain.Models;
using CinemaApp1.Application.DTOs.Movie;
using System.ComponentModel.DataAnnotations;

namespace CinemaApp1.Application.DTOs.Screening
{
    public class ScreeningResponseDTO
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public decimal ticketPrice { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public bool IsPast { get; set; }
        public MovieResponseDTO Movie { get; set; }

    }
}
