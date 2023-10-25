namespace Kreddit.shared.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    
    public DateOnly CreatedAt { get; set; }
    public User(string username = "")
    {
        Username = username;
    }
    public User()
    {
        Id = 0;
        Username = "";
    }
}