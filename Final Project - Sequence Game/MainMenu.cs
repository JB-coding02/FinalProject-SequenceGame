using Microsoft.Data.SqlClient;



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

        txtPlayerEmail.Text = Email;
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

    private void BtnPlay_Click(object sender, EventArgs e)
    {
        GameBoard gameBoard = new GameBoard();
        gameBoard.Show();
        this.Close();
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