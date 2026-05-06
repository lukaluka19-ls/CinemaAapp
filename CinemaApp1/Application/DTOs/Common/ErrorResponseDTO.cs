using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp1.Application.DTOs.Common
{
    public class ErrorResponseDTO
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? Details { get; set; }
    }
}
