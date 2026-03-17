using Final_Project___Sequence_Game.Data;
using Final_Project___Sequence_Game.Models;

namespace Final_Project___Sequence_Game;

/// <summary>
/// Represents the form for creating a new player account in the sequence game.
/// Handles user input validation, database operations, and account creation functionality using Entity Framework Core.
/// </summary>
public partial class CreateAccount : Form
{
    public CreateAccount()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Handles the Create Account button click event.
    /// Validates all input fields, checks for duplicate credentials, and creates a new account if validation succeeds.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">The event arguments.</param>
    private void btnCreateAccount_Click(object sender, EventArgs e)
    {
        if (txtUsername.Text.IsWhiteSpace() || txtPassword.Text.IsWhiteSpace() || txtEmail.Text.IsWhiteSpace())
        {
            MessageBox.Show("Please fill in all fields.");
            return;
        }

        using (var ctx = new SequenceGameDbContext())
        {
            bool exists = ctx.PlayerData.Any(p => p.Username == txtUsername.Text || p.PlayerEmail == txtEmail.Text);

            if (!exists)
            {
                var player = new PlayerData
                {
                    Username = txtUsername.Text,
                    PasswordHash = txtPassword.Text,
                    PlayerEmail = txtEmail.Text
                };
                ctx.PlayerData.Add(player);
                ctx.SaveChanges();

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
    }

    /// <summary>
    /// Checks if the entered username already exists in the database.
    /// Updates the username field's background color to indicate validation status (red=duplicate, green=available).
    /// </summary>
    /// <returns>True if the username already exists in the database; otherwise, false.</returns>
    public bool CheckUsername()
    {
        if (txtUsername.Text.IsWhiteSpace())
        {
            MessageBox.Show("Please enter a username.");
            return false;
        }

        using (var ctx = new SequenceGameDbContext())
        {
            bool exists = ctx.PlayerData.Any(p => p.Username == txtUsername.Text);
            txtUsername.BackColor = exists ? Color.DarkRed : Color.LightGreen;
            return exists;
        }
    }
    /// <summary>
    /// Checks if the entered password matches one in the database.
    /// Updates the password field's background color to indicate validation status.
    /// </summary>
    /// <returns>True if the password already exists in the database; otherwise, false.</returns>
    public bool CheckPassword()
    {
        if (txtPassword.Text.IsWhiteSpace())
        {
            MessageBox.Show("Please enter a password.");
            return false;
        }

        using (var ctx = new SequenceGameDbContext())
        {
            bool exists = ctx.PlayerData.Any(p => p.PasswordHash == txtPassword.Text);
            txtPassword.BackColor = exists ? Color.DarkRed : Color.LightGreen;
            return exists;
        }
    }

    /// <summary>
    /// Checks if the entered email address already exists in the database.
    /// Updates the email field's background color to indicate validation status (red=duplicate, green=available).
    /// </summary>
    /// <returns>True if the email already exists in the database; otherwise, false.</returns>
    public bool CheckEmail()
    {
        if (txtEmail.Text.IsWhiteSpace())
        {
            MessageBox.Show("Please enter an email.");
            return false;
        }

        using (var ctx = new SequenceGameDbContext())
        {
            bool exists = ctx.PlayerData.Any(p => p.PlayerEmail == txtEmail.Text);
            txtEmail.BackColor = exists ? Color.DarkRed : Color.LightGreen;
            return exists;
        }
    }
    // Connection string and ADO helpers removed — EF Core is used via
    // SequenceGameContext and DbConfig.GetConnectionString().
}
