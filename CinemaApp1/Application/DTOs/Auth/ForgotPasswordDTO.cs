using System.ComponentModel.DataAnnotations;

namespace CinemaApp1.Application.DTOs.Auth
{
    public class ForgotPasswordDTO
    {
        [Required(ErrorMessage = "Email is needed")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;
    }
}
