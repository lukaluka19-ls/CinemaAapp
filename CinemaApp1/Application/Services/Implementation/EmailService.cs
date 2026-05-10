using CinemaApp1.Application.DTOs.Email;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace CinemaApp1.Application.Services.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private async Task SendAsync(string to, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(_configuration["Email:From"]));
            message.To.Add(MailboxAddress.Parse(to));
            message.Subject = subject;
            message.Body = new TextPart("plain") { Text = body };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(
                _configuration["Email:Username"],
                _configuration["Email:Password"]);
            await smtp.SendAsync(message);
            await smtp.DisconnectAsync(true);
        }

        public async Task SendVerificationEmailAsync(VerificationEmailDTO dto)
        {
            await SendAsync(
                dto.To,
                "Account Verification - CinemaApp",
                $"Hello {dto.UserName}, please verify your account: {dto.VerificationLink}");
        }

        public async Task SendResetPasswordEmailAsync(ResetPasswordEmailDTO dto)
        {
            await SendAsync(
                dto.To,
                "Password Reset - CinemaApp",
                $"Hello {dto.UserName}, reset your password here: {dto.ResetLink}");
        }

        public async Task SendReservationConfirmationEmailAsync(ReservationConfirmationEmailDTO dto)
        {
            await SendAsync(
                dto.To,
                "Reservation Confirmation - CinemaApp",
                $"Hello {dto.UserName}, your reservation for {dto.MovieName} is confirmed. Code: {dto.UniqueCode}");
        }
    }
}