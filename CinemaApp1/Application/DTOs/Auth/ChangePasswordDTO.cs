using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CinemaApp.BusinessLayer.Validators;

namespace CinemaApp1.Application.DTOs.Auth
{
    [PasswordsDifferent]
    public class ChangePasswordDTO
    {
        [Required(ErrorMessage = "Current password is required!")]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "New password is required!")]
        [MinLength(8, ErrorMessage = "New password must be at least 8 characters long!")]
        public string NewPassword { get; set; } = string.Empty;

        [Compare("NewPassword", ErrorMessage = "Passwords do not match!")]
        public string ConfirmNewPassword { get; set; } = string.Empty;
    }
}
