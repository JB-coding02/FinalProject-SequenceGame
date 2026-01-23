using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Final_Project___Sequence_Game.Classes;

public class CardData
{
    /// <summary>
    /// A two character string with the first character being the suit 
    /// (i.g.H = Hearts, S = Spades, C = Clubs, D = Diamonds) the second
    /// Character meaning the Value of the card
    /// (i.g. 2-10 meaning all numbered cards,
    /// while A = Ace, J = Jack, Q = Queen, and K = King)
    /// </summary>
    [Key]
    [Required]
    public required string CardIdentity 
    { 
        get { return CardIdentity; }
        set
        {
            CardIdentity = value;
        }
    }
}
