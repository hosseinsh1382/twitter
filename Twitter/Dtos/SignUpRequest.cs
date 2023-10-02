namespace Twitter.Dtos;

public class SignUpRequest
{
    public string AccountName { get; init; }
    public string Username { get; init; }
    public string Password { get; init; }
    public string? Fullname { get; init; }
    public string Email { get; init; }
    public string? Biography { get; init; }
}