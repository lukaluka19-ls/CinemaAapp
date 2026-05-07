public class ApiResponseDTO<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }

    public static ApiResponseDTO<T> Ok(T data, string? message = null) => new()
    {
        Success = true,
        Message = message,
        Data = data
    };

    public static ApiResponseDTO<T> Fail(string message) => new()
    {
        Success = false,
        Message = message,
        Data = default
    };
}