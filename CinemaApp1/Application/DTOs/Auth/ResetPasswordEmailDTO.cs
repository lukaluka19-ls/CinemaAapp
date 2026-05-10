public class ResetPasswordEmailDTO
{
    public string To { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string ResetLink { get; set; } = null!;
}