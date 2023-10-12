namespace Kreddit.shared.Models;

public class Post
{
    public int Id { get; set; }
    
    public string Title { get; set; } = null!;
    
    public string Content { get; set; } = null!;
    
    public User User { get; set; } = null!;
    
    public List<Comment> Comments { get; set; } = null!;
    
    public int Upvotes { get; set; }
    
    public int Downvotes { get; set; }
    
    public DateOnly CreatedAt { get; set; }
}