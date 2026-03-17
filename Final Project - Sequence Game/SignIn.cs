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
    /// Check if the entered password matches the stored one for the user.
    /// </summary>
    /// <returns>True if password matches.</returns>
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
    /// Check if email matches the stored email for the user.
    /// </summary>
    /// <returns>True if email matches.</returns>
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
    // ADO helpers removed. EF Core is used.

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