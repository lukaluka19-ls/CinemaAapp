using System.ComponentModel.DataAnnotations;

namespace CinemaApp1.Application.DTOs.Auth
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email Or Username is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string EmailOrUsername { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; } = string.Empty;
    }
}
