using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project___Sequence_Game.Models;

[Table("PlayerData")]
public class PlayerData
{
    [Key]
    public int PlayerId { get; set; }

    public string Username { get; set; } = string.Empty;

    // Storing raw password is not secure; consider hashing in future.
    public string PasswordHash { get; set; } = string.Empty;

    public string PlayerEmail { get; set; } = string.Empty;
}
