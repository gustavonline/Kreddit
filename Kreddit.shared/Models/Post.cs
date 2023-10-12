namespace Kreddit.shared.Models;

public class Post
{
    public int Id { get; set; }
    
    public string Title { get; set; } = null!;
    
    public string Content { get; set; } = null!;
    
    public User User { get; set; } = null!;
    
    Public list<Comment> Comments { get; set; } = null!;
    
    Public int Upvotes { get; set; }
    
    Public int Downvotes { get; set; }
    
    public DateOnly CreatedAt { get; set; }
}