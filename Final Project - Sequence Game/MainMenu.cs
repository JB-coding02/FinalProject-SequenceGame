using Microsoft.Identity.Client;
using Final_Project___Sequence_Game.Data;



namespace Final_Project___Sequence_Game;

/// <summary>
/// Represents the main menu form displayed after player authentication.
/// Provides navigation to game functionality and user information display.
/// </summary>
public partial class MainMenu : Form
{

    public MainMenu()
    {
        InitializeComponent();
    }

    public MainMenu(string? Username, string? Email)
    {
        InitializeComponent();

        txtEmail.Text = Email;
        txtUsername.Text = Username;
    }

    /// <summary>
    /// Handles the Play button click event.
    /// Creates and displays a new GameBoard form, passing the current player's username.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">The event arguments.</param>
    private void BtnPlay_Click(object sender, EventArgs e)
    {
        GameBoard gameBoard = new GameBoard(txtUsername.Text);
        gameBoard.Show();
        this.Hide();
    }

    /// <summary>
    /// Handles the Sign In button click event.
    /// Displays the sign-in form and hides the current main menu form.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">The event arguments.</param>
    private void btnSignIn_Click(object sender, EventArgs e)
    {
        SignIn signIn = new SignIn();
        signIn.Show();
        this.Hide();
    }

    /// <summary>
    /// Handles the Exit Game button click event.
    /// Closes the application.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">The event arguments.</param>
    private void btnExitGame_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}