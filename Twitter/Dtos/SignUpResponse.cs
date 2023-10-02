namespace Twitter.Dtos;

public class SignUpResponse
{
    public string Username { get; init; }
    public string? Fullname { get; init; }
    public string Email { get; init; }
    public string AccountName { get; init; }
    public DateTime JoinedDate { get; init; }

    public string Message { get; init; } = string.Empty;
}