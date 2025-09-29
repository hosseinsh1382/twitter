namespace Twitter.Models;

public class Account
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string AccountName { get; set; }
    public string Password { get; set; }
    public string? Fullname { get; set; }
    public string Email { get; set; }
    public string Biography { get; set; } = string.Empty;
    public DateTime JoinedDate { get; init; } = DateTime.Now; 
    public IEnumerable<Account> Following { get; set; } = Enumerable.Empty<Account>();
    public IEnumerable<Account> Follower { get; set; } = Enumerable.Empty<Account>();
}