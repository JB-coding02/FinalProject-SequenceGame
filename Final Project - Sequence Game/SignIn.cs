using Final_Project___Sequence_Game.Data;

namespace Final_Project___Sequence_Game;

public partial class SignIn : Form
{
    public SignIn()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Checks if the entered Username matches 
    /// another Username stored in the database.
    /// </summary>
    /// <returns>True if the entered Username matches the stored 
    /// Username for that account, but returns false if it doesn't match</returns>
    public bool CheckUsername()
    {
        bool exists = false;
        if (!txtUsername.Text.IsWhiteSpace())
        {
            using var ctx = new SequenceGameDbContext();
            exists = ctx.PlayerData.Any(p => p.Username == txtUsername.Text);
            txtUsername.BackColor = exists ? Color.LightGreen : Color.DarkRed;
        }
        return exists;
    }
    /// <summary>
    /// Checks if the entered password Matches one in the database.
    /// </summary>
    /// <returns>True if the entered password matches the stored 
    /// password for that account, but returns false if it doesn't match</returns>
    public bool CheckPassword()
    {
        bool match = false;
        if (!txtPassword.Text.IsWhiteSpace() && !txtUsername.Text.IsWhiteSpace())
        {
            using var ctx = new SequenceGameDbContext();
            match = ctx.PlayerData.Any(p => p.Username == txtUsername.Text && p.PasswordHash == txtPassword.Text);
            txtPassword.BackColor = match ? Color.LightGreen : Color.DarkRed;
        }
        return match;
    }

    /// <summary>
    /// Checks if the entered Email matches 
    /// another Email stored in the database.
    /// </summary>
    /// <returns>True if the entered Email matches the stored 
    /// Email for that account, but returns false if it doesn't match</returns>
    public bool CheckEmail()
    {
        bool match = false;
        if (!txtEmail.Text.IsWhiteSpace() && !txtUsername.Text.IsWhiteSpace())
        {
            using var ctx = new SequenceGameDbContext();
            match = ctx.PlayerData.Any(p => p.Username == txtUsername.Text && p.PlayerEmail == txtEmail.Text);
            txtEmail.BackColor = match ? Color.LightGreen : Color.DarkRed;
        }
        return match;
    }
    // ADO helpers removed — EF Core via SequenceGameContext is used instead.

    private void btnSignIn_Click(object sender, EventArgs e)
    {
        if (!txtUsername.Text.IsWhiteSpace() && !txtPassword.Text.IsWhiteSpace() && !txtEmail.Text.IsWhiteSpace())
        {
            if (CheckUsername() && CheckPassword() && CheckEmail())
            {
                MessageBox.Show("Sign In Successful!");
                MainMenu mainMenu = new MainMenu(txtUsername.Text, txtEmail.Text);
                mainMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sign In Failed. Please re-check your credentials.");
            }
        }
        else
        {
            MessageBox.Show("Please fill in all fields.");
        }
    }

    private void btnCreateAccount_Click(object sender, EventArgs e)
    {
        CreateAccount createAccount = new CreateAccount();
        createAccount.Show();
        this.Hide();
    }
}