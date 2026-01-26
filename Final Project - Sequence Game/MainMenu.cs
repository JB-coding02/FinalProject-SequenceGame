namespace Final_Project___Sequence_Game;

public partial class MainMenu : Form
{
    public MainMenu()
    {
        InitializeComponent();
    }

    public string[,] CreateGrid()
    {
        string[,] grid = new string[10, 10];

        //for (int row = 0; row < 10; row++)
        //{
        //    for (int col = 0; col < 10; col++)
        //    {
        //        return grid;
        //    }
        //}

        return grid;
    }

    // Need to set each grid slot to specific card values
    public string[,] GetGrid()
    {
        string[,] gameGrid = CreateGrid();
        return gameGrid;
    }

    public void setSridValues()
        {
        string[,] grid = GetGrid();
        for (int i = 0; i < grid[].Length; i++)
        {
            grid[0, 0] = "FREE";
        } // Example of setting a specific grid slot to a card value
    }

}
