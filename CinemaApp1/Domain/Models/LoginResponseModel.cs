namespace CinemaApp1.Domain.Models
{
    public class LoginResponseModel
    {
        public string? Username { get; set; }
        public string? AccessToken { get; set; }
        public int EpiresIn { get; set; }
        //public string Password { get; internal set; }
    }
}
