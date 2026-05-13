namespace CinemaApp1.Application.Exceptions
{
    public sealed class UnprocessableException : Exception
    {
        public UnprocessableException(string message) : base(message) { }
    }
}
