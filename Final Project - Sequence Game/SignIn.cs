using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
        bool UsernameMatch = false;
        if (!txtUsername.Text.IsWhiteSpace())
        {
            using (SqlConnection conn = GetSqlConnection())
            {
                conn.Open();
                string query =
                    $"""
                    SELECT Username 
                    FROM PlayerData 
                    WHERE Username = '{txtUsername.Text}',
                    PlayerEmail = '{txtEmail.Text}',
                    PasswordHash = '{txtPassword.Text}'
                    """; // example table
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["Username"].ToString() == txtUsername.Text)
                    {
                        UsernameMatch = true;
                        txtUsername.BackColor = Color.LightGreen;
                        break;
                    }
                    else
                    {
                        txtUsername.BackColor = Color.DarkRed;
                        break;
                    }
                }
            }
        }
        return UsernameMatch;
    }
    /// <summary>
    /// Checks if the entered password Matches one in the database.
    /// </summary>
    /// <returns>True if the entered password matches the stored 
    /// password for that account, but returns false if it doesn't match</returns>
    public bool CheckPassword()
    {
        bool PasswordMatch = false;
        if (!txtPassword.Text.IsWhiteSpace())
        {
            using (SqlConnection conn = GetSqlConnection())
            {
                conn.Open();
                string PasswordQuery = $"""
                        SELECT PasswordHash 
                        FROM PlayerData 
                        WHERE PasswordHash = '{txtPassword.Text}',
                        PlayerEmail = '{txtEmail.Text}',
                        Username = '{txtUsername.Text}'
                        """;
                SqlCommand PasswordCmd = new SqlCommand(PasswordQuery, conn);
                SqlDataReader PasswordReader = PasswordCmd.ExecuteReader();

                while (PasswordReader.Read())
                {
                    if (PasswordReader["Password"].ToString() == txtPassword.Text)
                    {
                        txtPassword.BackColor = Color.LightGreen;
                        PasswordMatch = true;
                        break;
                    }
                    else
                    {
                        txtPassword.BackColor = Color.DarkRed;
                        break;
                    }
                }
            }
        }
        return PasswordMatch;
    }

    /// <summary>
    /// Checks if the entered Email matches 
    /// another Email stored in the database.
    /// </summary>
    /// <returns>True if the entered Email matches the stored 
    /// Email for that account, but returns false if it doesn't match</returns>
    public bool CheckEmail()
    {
        bool EmailMatch = false;
        if (!txtEmail.Text.IsWhiteSpace())
        {
            using (SqlConnection conn = GetSqlConnection())
            {
                conn.Open();
                string EmailQuery = $"""
                        SELECT PlayerEmail 
                        FROM PlayerData 
                        WHERE PasswordHash = '{txtPassword.Text}',
                        PlayerEmail = '{txtEmail.Text}',
                        Username = '{txtUsername.Text}'
                        """;
                SqlCommand EmailCmd = new SqlCommand(EmailQuery, conn);
                SqlDataReader EmailReader = EmailCmd.ExecuteReader();

                while (EmailReader.Read())
                {
                    if (EmailReader["PlayerEmail"].ToString() == txtEmail.Text)
                    {
                        txtEmail.BackColor = Color.LightGreen;
                        EmailMatch = true;
                        break;
                    }
                    else
                    {
                        txtEmail.BackColor = Color.DarkRed;
                        break;
                    }
                }
            }
        }
        return EmailMatch;
    }

    public SqlConnection GetSqlConnection()
    {
        string connectionString = getConnectionString();
        return new SqlConnection(connectionString);
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