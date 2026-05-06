using System;

namespace CinemaApp.Domain.Models
{
    public class Rating
    {
        public int Id { get; set; }

        public int Score { get; set; } // 1-5

        public string? Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; } = null!;

        public int UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;
    }
}