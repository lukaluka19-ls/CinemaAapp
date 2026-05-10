using CinemaApp1.Application.DTOs.Email;

public interface IEmailService
{
    Task SendVerificationEmailAsync(VerificationEmailDTO dto);
    Task SendResetPasswordEmailAsync(ResetPasswordEmailDTO dto);
    Task SendReservationConfirmationEmailAsync(ReservationConfirmationEmailDTO dto);
}