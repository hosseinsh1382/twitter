namespace Domain.Models;

public class Comment
{
    public Guid Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public required Guid PostId { get; set; }
    public required Guid AccountId { get; set; }
}