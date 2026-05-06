using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CinemaApp1.Application.DTOs.Rating
{
    public class RatingDTO
    {
        [Required(ErrorMessage = "Rating value is required!")]
        public int ReservationId { get; set; }

        [Range(1,5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Stars { get; set; }
    }
}
