using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project___Sequence_Game.Models;

[Table("PlayerData")]
public class PlayerData
{
    [Required]
    [Key]
    private int PlayerId
    {
        get { return PlayerId; }
        set
        {
            PlayerId = value;
        }
    }

    public string Username
    {
        get { return Username; }
        set
        {
            Username = value;
        }
    }

    // Storing raw password is not secure; consider hashing in future.
    public string PasswordHash { get; set; } = string.Empty;

    public string PlayerEmail { get; set; } = string.Empty;
}
