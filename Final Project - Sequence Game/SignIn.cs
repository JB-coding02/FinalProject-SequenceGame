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
    /// Checks if the entered password matches the stored password for the given username.
    /// Updates the password field's background color to indicate validation status.
    /// </summary>
    /// <returns>True if the password matches the stored password for the current username; otherwise, false.</returns>
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
    /// Checks if the entered email matches the email stored for the given username.
    /// Updates the email field's background color to indicate validation status.
    /// </summary>
    /// <returns>True if the email matches the stored email for the current username; otherwise, false.</returns>
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
    // ADO helpers removed — EF Core via SequenceGameContext is used instead.

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