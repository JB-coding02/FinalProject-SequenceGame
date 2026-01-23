using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Final_Project___Sequence_Game.Classes;

public class PlayerData
{
    /// <summary>
    /// A unique identifier for each player
    /// </summary>
    [Required]
    [Key]
    private int PlayerID 
    { 
        get { return PlayerID; }
        set
        {
            PlayerID = value;
        }
    }

    /// <summary>
    /// The player's chosen username
    /// </summary>
    [Required]
    public required string Username 
    { 
        get { return Username; }
        set
        {
            Username = value;
        }
    }
}
