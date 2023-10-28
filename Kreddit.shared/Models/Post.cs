using System.ComponentModel.DataAnnotations;

namespace Kreddit.shared.Models;

public class Post
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Title is required")]
    [StringLength(100, ErrorMessage = "Title can't be longer than 100 characters")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Content is required")]
    [StringLength(500, ErrorMessage = "Content can't be longer than 500 characters")]
    public string Content { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
    
    public List<Comment> Comments { get; set; } = new List<Comment>();
    
    public int Upvotes { get; set; }
    
    public int Downvotes { get; set; }
    
    public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    public Post(User user, string title = "", string content = "", int upvotes = 0, int downvotes = 0) {
        Title = title;
        Content = content;
        Upvotes = upvotes;
        Downvotes = downvotes;
        User = user;
    }
    
    public Post() {
        Id = 0;
        Title = "";
        Content = "";
        Upvotes = 0;
        Downvotes = 0;
        User = null;
    }
}