namespace Domain.Models;

public class Post
{
    public Guid Id { get; set; }
    public required string Text { get; set; }
    public IEnumerable<User> Viewers { get; set; } = [];
    public IEnumerable<User> Likes { get; set; } = [];
    public IEnumerable<Comment> Comments { get; set; } = [];
    public DateTime PublishDateTime { get; set; } = DateTime.UtcNow;
    public required Guid PublisherId { get; set; }
    public User? Publisher { get; set; }
}