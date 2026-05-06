using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Domain.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public int ReservationId { get; set; }
        public int Stars { get; set; }
        public DateTime CreatedAt { get; set; }

        public ApplicationUser User { get; set; }
        public Reservation Reservation { get; set; }
    }
}
