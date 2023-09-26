namespace Twitter.Models;

public class Post
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public IEnumerable<Account>? Viewrs { get; set; }
    public IEnumerable<Account>? Like { get; set; }
    public DateTime PublishDateTime { get; set; }

    public Guid AccountId { get; set; }
    public Account? Account { get; set; }

    public IEnumerable<Comment> Comments { get; set; }
}