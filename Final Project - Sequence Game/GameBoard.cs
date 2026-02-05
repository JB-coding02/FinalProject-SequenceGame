using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Final_Project___Sequence_Game;

public partial class GameBoard : Form
{
	/// <summary>
	/// The players username is passed to the GameBoard form 
    /// so that it can be used to track the players progress and 
    /// update the database with their wins and losses.
	/// </summary>
	/// <param name="PlayerUsername"></param>
	public GameBoard(string? PlayerUsername)
    {
        InitializeComponent();
    }

    public string[,] CreateGrid()
    {
        string[,] grid = new string[10, 10];
        return grid;
    }

    public string[,] GetGrid()
    {
        string[,] gameGrid = CreateGrid();
        return gameGrid;
    }

    public void SetGridValues()
    {
        string[,] grid = GetGrid();
        for (int row = 0; row < 10; row++)
        {
            for (int col = 0; col < 10; col++)
            {
                grid = GetCardArray();
            }
        }
    }

    public string[,] GetCardArray()
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


	/// <summary>
	/// Displays an enlarged version of the game board when the player clicks on the game board.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void ImgGameBoard_Click(object sender, EventArgs e)
    {
        ShowEnlargedGameBoard();
    }

	/// <summary>
	/// Shows a maginified version of the gameboard image, 
    /// along with a close button and buttons for the free spaces on the game board.
	/// </summary>
	private void ShowEnlargedGameBoard()
    {
        picZoomedInBoard.Visible = true;
        picZoomedInBoard.Enabled = true;
        picClose.Visible = true;
        picClose.Enabled = true;
        picClose.BringToFront();
        btnFreeSpace1.Visible = true;
        btnFreeSpace1.Visible = true;
        btnFreeSpace1.BringToFront();
        btnFreeSpace1.Enabled = true;
        btnFreeSpace2.Visible = true;
        btnFreeSpace2.BringToFront();
        btnFreeSpace2.Enabled = true;
    }

	/// <summary>
	/// Closes enlarged image of the game board when the player clicks the close button.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void picClose_Click(object sender, EventArgs e)
    {
        picZoomedInBoard.Visible = false;
        picZoomedInBoard.Enabled = false;
        picClose.Visible = false;
        picClose.Enabled = false;
    }

	/// <summary>
	/// detects when the player clicks on the free space buttons and displays a message box to confirm that they have clicked on the free space.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void btnFreeSpace1_Click(object sender, EventArgs e)
    {
        MessageBox.Show("You clicked the free space!");
    }

	/// <summary>
	/// detects when the player clicks on the free space buttons and displays a message box to confirm that they have clicked on the free space.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void btnFreeSpace2_Click(object sender, EventArgs e)
    {
        MessageBox.Show("You clicked the free space!");
    }
}
