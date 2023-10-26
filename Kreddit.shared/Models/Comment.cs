namespace Kreddit.shared.Models;

public class Comment
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public User User { get; set; }
    
    public int PostId { get; set; }
    
    public int Upvotes { get; set; }
    
    public int Downvotes { get; set; }
    
    public DateOnly Date { get; set; }
    
    public Comment(string title = "", int upvotes = 0, int downvotes = 0, User user = null)
    {
        Title = title;
        Upvotes = upvotes;
        Downvotes = downvotes;
        User = user;
    }
    public Comment() {
        Id = 0;
        Title = "";
        Upvotes = 0;
        Downvotes = 0;
    }
}