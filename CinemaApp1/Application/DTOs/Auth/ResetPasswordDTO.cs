using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CinemaApp1.Application.DTOs.Auth
{
    public class ResetPasswordDTO
    {
        public string UserID { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        [Required(ErrorMessage = "New password is required.")]
        [MinLength(8, ErrorMessage = "Password length can't be less than 8 characters.")]
        public string NewPassword { get; set; } = string.Empty;
        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;

    }
}
