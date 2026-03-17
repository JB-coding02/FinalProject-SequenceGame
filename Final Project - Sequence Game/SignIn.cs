using Final_Project___Sequence_Game.Data;

namespace Final_Project___Sequence_Game;

public partial class SignIn : Form
{
    public SignIn()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Check if username exists in the database.
    /// </summary>
    /// <returns>True if username exists.</returns>
    public bool CheckUsername()
    {
        if (txtUsername.Text.IsWhiteSpace())
        {
            return false;
        }

        using var ctx = new SequenceGameDbContext();
        bool exists = ctx.PlayerData.Any(p => p.Username == txtUsername.Text);
        txtUsername.BackColor = exists ? Color.LightGreen : Color.DarkRed;
        return exists;
    }
    /// <summary>
    /// Checks if the entered password Matches one in the database.
    /// </summary>
    /// <returns>True if the entered password matches the stored 
    /// password for that account, but returns false if it doesn't match</returns>
    public bool CheckPassword()
    {
        if (txtPassword.Text.IsWhiteSpace() || txtUsername.Text.IsWhiteSpace())
        {
            return false;
        }

        using var ctx = new SequenceGameDbContext();
        bool match = ctx.PlayerData.Any(p => p.Username == txtUsername.Text && p.PasswordHash == txtPassword.Text);
        txtPassword.BackColor = match ? Color.LightGreen : Color.DarkRed;
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
        if (txtEmail.Text.IsWhiteSpace() || txtUsername.Text.IsWhiteSpace())
        {
            return false;
        }

        using var ctx = new SequenceGameDbContext();
        bool match = ctx.PlayerData.Any(p => p.Username == txtUsername.Text && p.PlayerEmail == txtEmail.Text);
        txtEmail.BackColor = match ? Color.LightGreen : Color.DarkRed;
        return match;
    }
    // ADO helpers removed. EF Core is used.

    /// <summary>
    /// Handles the Sign In button click event.
    /// Validates all three credential fields and attempts to authenticate the user against the database.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">The event arguments.</param>
    private void btnSignIn_Click(object sender, EventArgs e)
    {
        if (txtUsername.Text.IsWhiteSpace() || txtPassword.Text.IsWhiteSpace() || txtEmail.Text.IsWhiteSpace())
        {
            MessageBox.Show("Please fill in all fields.");
            return;
        }

        using var ctx = new SequenceGameDbContext();
        var player = ctx.PlayerData.FirstOrDefault(p => 
            p.Username == txtUsername.Text && 
            p.PasswordHash == txtPassword.Text && 
            p.PlayerEmail == txtEmail.Text);

        if (player != null)
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

    /// <summary>
    /// Handles the Create Account button click event.
    /// Displays the account creation form and hides the current sign-in form.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">The event arguments.</param>
    private void btnCreateAccount_Click(object sender, EventArgs e)
    {
        CreateAccount createAccount = new CreateAccount();
        createAccount.Show();
        this.Hide();
    }
}