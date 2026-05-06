using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp1.Application.DTOs.Seat
{
    public class SeatResponseDto
    {
        public int Id { get; set; }
        public string SeatNumber { get; set; }
        public bool IsOccupied { get; set; }
        public string Status => IsOccupied ? "Occupied" : "Available";
    }
}
