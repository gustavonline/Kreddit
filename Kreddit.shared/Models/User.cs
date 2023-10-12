namespace Kreddit.shared.Models;

public class User
{
    public int Id { get; set; }
    
    public string Username { get; set; } = null!;
    
    public DateOnly CreatedAt { get; set; }
}