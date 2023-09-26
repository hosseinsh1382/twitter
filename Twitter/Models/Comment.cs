namespace Twitter.Models;

public class Comment
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    
    public Guid PostId { get; set; }
    
    public Guid AccountId { get; set; }
}