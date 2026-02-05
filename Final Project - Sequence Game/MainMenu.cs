using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;



namespace Final_Project___Sequence_Game;


/// <summary>
/// front page of the game, where players can choose to sign in, create an account, or play the game as a guest.
/// </summary>
public partial class MainMenu : Form
{

    public MainMenu()
    {
        InitializeComponent();
    }

	/// <summary>
	/// gets the players username and email from the SignIn form and displays it on the MainMenu form, 
    /// allowing the player to play the game with their account details without having to sign in again 
    /// after they have already signed in once. 
    /// This also allows the player to play the game as a guest if they choose to 
    /// by leaving the username and email fields blank.
	/// </summary>
	/// <param name="Username">Player's account username</param>
	/// <param name="Email">Players Linked Email</param>
	public MainMenu(string? Username, string? Email)
    {
        InitializeComponent();

        txtEmail.Text = Email;
        txtUsername.Text = Username;
    }

    public void getConnection()
    {
        string connString = getConnectionString();
    }


    public string getConnectionString()
    {
        return """
            Data Source=(localdb)\\MSSQLLocalDB;
            Initial Catalog=SequenceGameDB;
            Integrated Security=True;
            Connect Timeout=30;
            Encrypt=True;
            Trust Server Certificate=True;
            Application Intent=ReadWrite;M
            ulti Subnet Failover=False;
            Command Timeout=30
            """;
    }

    public SqlConnection GetConnection()
    {
        string connectionString = getConnectionString();
        return new SqlConnection(connectionString);
    }

	/// <summary>
	/// Begins the game by opening the GameBoard form and passing the player's username to it,
	/// or if the player is playing as a guest, it will pass an empty string to the GameBoard form.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void BtnPlay_Click(object sender, EventArgs e)
    {
        GameBoard gameBoard = new GameBoard(txtUsername.Text);
        gameBoard.Show();
        this.Hide();
    }

	/// <summary>
	/// Validates the player's account details and opens the SignIn form if the player chooses to sign in,
	/// if the player is playing as a guest, it will open the SignIn form with empty fields, 
    /// allowing the player to create an account if they choose to with the SignIn form title changed to "Create Account".
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void btnSignIn_Click(object sender, EventArgs e)
    {
        SignIn signIn = new SignIn();
        signIn.Show();
        this.Hide();
    }

	/// <summary>
	/// Closes the entire application when the player clicks the "Exit Game" button on the MainMenu form, 
	/// allowing the player to exit the game from the main menu without having to open the game board first.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void btnExitGame_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}