using System.ComponentModel.DataAnnotations;

namespace Kreddit.shared.Models;

public class User
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Username is required")]
    [StringLength(50, ErrorMessage = "Username can't be longer than 50 characters")]
    public string Username { get; set; }
    public User(string username = "") {
        Username = username;
    }
    public User() {
        Id = 0;
        Username = "";
    }
}