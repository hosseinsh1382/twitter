using Twitter.Models;

namespace Twitter.Dtos;

public record AccountDto
{
    public string Username { get; init; }
    public string AccountName { get; init; }
    public string? Fullname { get; init; }
    public string Email { get; init; }
    public string? Biography { get; init; }
    public DateTime JoinedDate { get; init; }
    public IEnumerable<Account> Following { get; init; }
    public IEnumerable<Account> Follower { get; init; } 
}