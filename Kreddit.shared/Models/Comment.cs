namespace Kreddit.shared.Models;

public class Comment
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public User User{ get; set; }
    
    public int PostId { get; set; }
    
    public int Upvotes { get; set; }
    
    public int Downvotes { get; set; }
    
    
    public DateOnly Date { get; set; }
    
    public Comment(User user, string content = "", int upvotes = 0, int downvotes = 0)
    {
        Title = Title;
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