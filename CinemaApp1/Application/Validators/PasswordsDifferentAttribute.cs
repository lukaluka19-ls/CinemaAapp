using System.ComponentModel.DataAnnotations;

namespace CinemaApp.BusinessLayer.Validators
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PasswordsDifferentAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dto = value as dynamic;

            if (dto?.CurrentPassword == null || dto?.NewPassword == null)
                return ValidationResult.Success;

            if (dto.CurrentPassword.Equals(dto.NewPassword, StringComparison.Ordinal))
            {
                return new ValidationResult("New password must be different from current password!");
            }

            return ValidationResult.Success;
        }
    }
}
