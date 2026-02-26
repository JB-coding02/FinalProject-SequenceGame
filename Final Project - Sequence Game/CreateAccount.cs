using Final_Project___Sequence_Game.Data;
using Final_Project___Sequence_Game.Models;

namespace Final_Project___Sequence_Game;

public partial class CreateAccount : Form
{
    public CreateAccount()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Upon Create account button press checks if the entered 
    /// details are valid and creates a new account in the 
    /// database if the entered details are unique.
    /// </summary>
    private void btnCreateAccount_Click(object sender, EventArgs e)
    {
         bool usernameExists = CheckUsername();
         bool emailExists = CheckEmail();
         if (!usernameExists && !emailExists)
         {
            using (var ctx = new SequenceGameDbContext())
            {
                var player = new PlayerData
                {
                    Username = txtUsername.Text,
                    PasswordHash = txtPassword.Text,
                    PlayerEmail = txtEmail.Text
                };
                ctx.PlayerData.Add(player);
                ctx.SaveChanges();
            }
            MessageBox.Show("Account created successfully!");
            this.Hide();
            SignIn signInForm = new SignIn();
            signInForm.Show();
         }
         else
         {
            MessageBox.Show("Username or Email is already in use.");
         }
    }

    /// <summary>
    /// Checks if the entered Username matches 
    /// another Username stored in the database.
    /// </summary>
    /// <returns>True if the entered Username matches a stored 
    /// Username for an account, but returns false if it doesn't match</returns>
    public bool CheckUsername()
    {
        bool exists = false;
        if (!txtUsername.Text.IsWhiteSpace())
        {
            using (var ctx = new SequenceGameDbContext())
            {
                exists = ctx.PlayerData.Any(p => p.Username == txtUsername.Text);
            }
            txtUsername.BackColor = exists ? Color.DarkRed : Color.LightGreen;
        }
        else
        {
            MessageBox.Show("Please enter a username.");
        }
        return exists;
    }
    /// <summary>
    /// Checks if the entered password matches one in the database.
    /// </summary>
    /// <returns>True if the entered password matches a stored 
    /// password for an account, but returns false if it doesn't match</returns>
    public bool CheckPassword()
    {
        // For account creation this method isn't typically used, but keep
        // a simple existence check for the password value.
        bool exists = false;
        if (!txtPassword.Text.IsWhiteSpace())
        {
            using (var ctx = new SequenceGameDbContext())
            {
                exists = ctx.PlayerData.Any(p => p.PasswordHash == txtPassword.Text);
            }
            txtPassword.BackColor = exists ? Color.DarkRed : Color.LightGreen;
        }
        else
        {
            MessageBox.Show("Please enter a password.");
        }
        return exists;
    }

    /// <summary>
    /// Checks if the entered Email matches 
    /// another Email stored in the database.
    /// </summary>
    /// <returns>True if the entered Email matches a stored 
    /// Email for an account, but returns false if it doesn't match</returns>
    public bool CheckEmail()
    {
        bool exists = false;
        if (!txtEmail.Text.IsWhiteSpace())
        {
            using (var ctx = new SequenceGameDbContext())
            {
                exists = ctx.PlayerData.Any(p => p.PlayerEmail == txtEmail.Text);
            }
            txtEmail.BackColor = exists ? Color.DarkRed : Color.LightGreen;
        }
        else
        {
            MessageBox.Show("Please enter an email.");
        }
        return exists;
    }
    // Connection string and ADO helpers removed — EF Core is used via
    // SequenceGameContext and DbConfig.GetConnectionString().
}
