using Microsoft.Data.SqlClient;



namespace Final_Project___Sequence_Game;


public partial class MainMenu : Form
{
    public MainMenu()
    {
        InitializeComponent();
    }

    public void getConnection()
    {
        string connString = getConnectionString();

        //using (SqlConnection conn = new SqlConnection(connString))
        //{
        //    conn.Open();

        //    string query = "SELECT * FROM Animals"; // example table
        //    SqlCommand cmd = new SqlCommand(query, conn);

        //    SqlDataReader reader = cmd.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        Console.WriteLine(reader["Name"].ToString());
        //    }
        //}
    }


    public string getConnectionString()
    {
        return """
            Data Source=(localdb)\\MSSQLLocalDB;
            Initial Catalog=SequenceGame;
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
        this.Hide();
    }
}