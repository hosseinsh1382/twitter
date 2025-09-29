namespace Twitter.Models;

public class Post
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public IEnumerable<Account> Viewers { get; set; } = Enumerable.Empty<Account>();
    public IEnumerable<Account> Likes { get; set; } = Enumerable.Empty<Account>();
    public IEnumerable<Comment> Comments { get; set; } = Enumerable.Empty<Comment>();
    public DateTime PublishDateTime { get; set; }

    public Guid AccountId { get; set; }
    public Account? Account { get; set; }
}