using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Twitter.Models;

namespace Twitter.Dtos;

public record PostResponse
{
    public string Text { get; set; }
    public IEnumerable<Account> Viewers { get; init; }
    public IEnumerable<Account> Likes { get; init; }
    public IEnumerable<Comment> Comments { get; init; }
    public DateTime PublishDateTime { get; init; }

    public Account Account { get; init; }
}