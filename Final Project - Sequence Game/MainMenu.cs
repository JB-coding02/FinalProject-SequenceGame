using Microsoft.Identity.Client;
using Final_Project___Sequence_Game.Data;



namespace Final_Project___Sequence_Game;


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

    public void getConnection()
    {
        string connString = DbConfig.GetConnectionString();
    }


    public string getConnectionString()
    {
        return DbConfig.GetConnectionString();
    }

    private void BtnPlay_Click(object sender, EventArgs e)
    {
        GameBoard gameBoard = new GameBoard(txtUsername.Text);
        gameBoard.Show();
        this.Hide();
    }

    private void btnSignIn_Click(object sender, EventArgs e)
    {
        SignIn signIn = new SignIn();
        signIn.Show();
        this.Hide();
    }

    private void btnExitGame_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}