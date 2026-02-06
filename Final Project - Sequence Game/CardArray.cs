using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project___Sequence_Game;

/// <summary>
/// This Array represents the 10x10 grid of cards that is used in the Sequence Game. 
/// Each element of the array is a string that represents a card, 
/// with the first character(s) representing the rank and the last character representing the suit. 
/// For example, "2S" represents the 2 of Spades, "AH" represents the Ace of Hearts, 
/// and "10D" represents the 10 of Diamonds. 
/// The "FREE" elements represent the free spaces on the game board count as a pre-claimed space for all players.
/// </summary>
public class CardArray
{
    public string[,] CreateCardArray()
    {
        string[,] cardArray = new string[10, 10]
        {
            { "FREE", "2S", "3S", "4S", "5S", "6S", "7S", "8S", "9S", "FREE" },
            { "6C", "5C", "4C", "3C", "2C", "AH", "KH", "QH", "10H", "10S" },
            { "7C", "AS", "2D", "3D", "4D", "5D", "6D", "7D", "9H", "QS" },
            { "8C", "KS", "6C", "5C", "4C", "3C", "2C", "8D", "8H", "KS" },
            { "9C", "QS", "7C", "6H", "5H", "4H", "AH", "9D", "7H", "AS" },
            { "10C", "10S", "8C", "7H", "2H", "3H", "KH", "10D", "6H", "2D" },
            { "QC", "9S", "9C", "8H", "9H", "10H", "QH", "QD", "5H", "3D" },
            { "KC", "8S", "10C", "QC", "KC", "AC", "AD", "KD", "4H", "4D" },
            {  "AC", "7S", "6S", "5S", "4S", "3S", "2S", "2H", "3H", "5D" },
            {  "FREE", "AD", "KD", "QD", "10D", "9D", "8D", "7D", "6D", "FREE" }
        };
        return cardArray;
    }
}
