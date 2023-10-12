namespace Kreddit.shared.Models;

public class Comment
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public User User { get; set; }
    
    public int Upvotes { get; set; }
    
    public int Downvotes { get; set; }
    
    public DateOnly Date { get; set; }
}