namespace Twitter.Dtos;

public class SignUpRespond
{
    public string Username { get; set; }
    public string? Fullname { get; set; }
    public string Email { get; set; }
    public string AccountName { get; set; }
    public DateTime JoinedDate { get; set; }
}