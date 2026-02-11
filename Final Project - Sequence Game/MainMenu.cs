using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;



namespace Final_Project___Sequence_Game;


public partial class MainMenu : Form
{
    public MainMenu(string Username, string Email)
    {
        InitializeComponent();
        txtUsername.Text = Username;
        txtEmail.Text = Email;
    }

    public MainMenu()
    {
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
}