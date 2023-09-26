namespace Twitter.Models;

public class Account
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string AccountName { get; set; }
    public string Password { get; set; }
    public string? Fullname { get; set; }
    public string Email { get; set; }
    public string? Biography { get; set; }
    public DateTime JoinedDate { get; set; }
    public List<Account>? Following { get; set; }
    public List<Account>? Follower { get; set; }
}