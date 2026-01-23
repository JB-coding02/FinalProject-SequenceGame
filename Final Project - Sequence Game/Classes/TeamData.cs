using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Final_Project___Sequence_Game.Classes;

public class TeamData
{
    /// <summary>
    /// A unique identifier for each team
    /// </summary>
    [Required]
    [Key]
    private int TeamID 
    { 
        get { return TeamID; }
        set
        {
            TeamID = value;
        }
    }

    /// <summary>
    /// The name of the team
    /// </summary>
    [Required]
    public required string TeamName 
    { 
        get { return TeamName; }
        set
        {
            if (!string.IsNullOrEmpty(TeamName))
            {
                TeamName = value;
            }
            else
            {
                throw new ArgumentException("Team name cannot be null or empty.");
            }
        }
    }

    /// <summary>
    /// A list of unique identifiers for each
    /// player in the team obtained by following
    /// the foreign key PlayerId but the list can
    /// be null
    /// </summary>
    public List<PlayerData> TeamMembers 
    {
        get {  return TeamMembers; }
        set
        {
            TeamMembers = value;
        }
    }
}
