using System.ComponentModel.DataAnnotations;

namespace Makhazen.Models;
public class User
{
    public int UserID { get; set; }
    [Required] public string FirstName { get; set; } = string.Empty;
    [Required] public string LastName { get; set; } = string.Empty;
    [Required] public string Username { get; set; } = string.Empty;
    // stored hashed password in DB column named `Password`
    [Required]
    public string Password { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
