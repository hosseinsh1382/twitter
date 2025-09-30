namespace Domain.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Username { get; set; }
    public required string HashedPassword { get; set; }
    public string Fullname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Biography { get; set; } = string.Empty;
    public DateTime JoinedDate { get; init; } = DateTime.Now;
    public IEnumerable<User> Following { get; set; } = [];
    public IEnumerable<User> Follower { get; set; } = [];
}