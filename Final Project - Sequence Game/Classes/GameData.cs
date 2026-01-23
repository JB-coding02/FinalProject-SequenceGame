using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Final_Project___Sequence_Game.Classes;

/// <summary>
/// Data structure to hold information about an individual game
/// </summary>
public class GameData
{
    /// <summary>
    /// A unique identifier for each game
    /// </summary>
    [Required]
    [Key]
    private int GameID 
    { 
        get { return GameID; }
        set
        {
            GameID = value;
        }
    }

    /// <summary>
    /// The number of teams participating in the game
    /// </summary>
    [Required]
    private List<TeamData> ParticipatingTeams 
    { 
        get { return ParticipatingTeams; }
        set
        {
            ParticipatingTeams = value;
        }
    }

    public 

    /// <summary>
    /// A list of cards found in the deck at the start of the game obtained using CardIdentity with a maximum of 104 Cards
    /// </summary>
    [Required]
    private List<CardData> DeckOfCards 
    { 
        get { return DeckOfCards; }
        set
        {
            DeckOfCards = value;
        }
    }

    /// <summary>
    /// The total number of players currently in the game
    /// </summary>
    [Required]
    private List<PlayerData> PlayersInGame 
    { 
        get { return PlayersInGame; }
        set
        {
            PlayersInGame = value;
        }
    }

    /// <summary>
    /// A list of cards that have been discarded during the game obtained using CardIdentity
    /// </summary>
    [Required]
    private List<CardData> DiscardedCards 
    { 
        get { return DiscardedCards; }
        set
        {
            DiscardedCards = value;
        }
    }

    /// <summary>
    /// The TeamName of the Team that won the game obtained by following TeamId
    /// </summary>
    [Required]
    private TeamData WinningTeam 
    { 
        get { return WinningTeam; }
        set
        {
            WinningTeam = value;
        }
    }

    /// <summary>
    /// The time the game started
    /// </summary>
    [Required]
    private DateTime GameStartTime 
    { 
        get { return Convert.ToDateTime(GameStartTime); }
        set
        {
            GameStartTime = value;
        }
    }

    /// <summary>
    /// The time the game ended
    /// </summary>
    [Required]
    private DateTime GameEndTime 
    { 
        get { return Convert.ToDateTime(GameEndTime); }
        set
        {
            GameEndTime = value;
        }
    }

    /// <summary>
    /// Length of time the game lasted for without a winner
    /// </summary>
    [Required]
    private DateTime GameDuration
    {
        get { return GameDuration; }
        set
        {
            GameDuration = value;
        }
    }

    /// <summary>
    /// The number of cards dealt to each player at the start of the game
    /// </summary>
    [Required]
    public required int CardsPerPlayer 
    { 
        get { return CardsPerPlayer; }
        set
        {
            CardsPerPlayer = value;
        }
    }

    /// <summary>
    /// The total number of teams in the game
    /// </summary>
    [Required]
    public required int TotalTeams 
    { 
        get { return TotalTeams; }
        set
        {
            TotalTeams = value;
        }
    }

    /// <summary>
    /// The unique identifier for each Team (up to 3 teams)
    /// </summary>
    [Required]
    public required int Team1Id 
    { 
        get { return Team1Id; }
        set
        {
            Team1Id = value;
        }
    }


}
