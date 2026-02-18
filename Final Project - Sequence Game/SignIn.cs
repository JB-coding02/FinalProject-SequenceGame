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
    /// Attempts to authenticate a user by username and password.
    /// On success returns true and outputs the associated email.
    /// Uses parameterized query to avoid SQL injection.
    /// </summary>
    public bool TryAuthenticate(string username, string password, out string email)
    {
        email = string.Empty;
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            return false;

        using (SqlConnection conn = GetSqlConnection())
        {
            conn.Open();
            const string sql = @"SELECT PlayerEmail FROM PlayerData WHERE Username = @username AND PasswordHash = @password";
            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            object result = cmd.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                email = Convert.ToString(result);
                txtUsername.BackColor = Color.LightGreen;
                txtPassword.BackColor = Color.LightGreen;
                return true;
            }
            else
            {
                txtUsername.BackColor = Color.DarkRed;
                txtPassword.BackColor = Color.DarkRed;
                return false;
            }
        }
    }

    public SqlConnection GetSqlConnection()
    {
        string connectionString = getConnectionString();
        return new SqlConnection(connectionString);
    }

    public string getConnectionString()
    {
        return """
            Data Source=(localdb)\MSSQLLocalDB;
            Initial Catalog=SequenceGameDB;
            Integrated Security=True;
            Connect Timeout=30;
            Encrypt=True;
            Trust Server Certificate=False;
            Command Timeout=30
            """;
    }



    private void btnSignIn_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text?.Trim() ?? string.Empty;
        string password = txtPassword.Text?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            MessageBox.Show("Please enter both username and password.");
            return;
        }

        if (TryAuthenticate(username, password, out string email))
        {
            MessageBox.Show("Sign In Successful!");
            MainMenu mainMenu = new MainMenu(username, email);
            mainMenu.Show();
            this.Hide();
        }
        else
        {
            MessageBox.Show("Sign In Failed. Please re-check your credentials.");
        }
    }

    private void btnCreateAccount_Click(object sender, EventArgs e)
    {
        CreateAccount createAccount = new CreateAccount();
        createAccount.Show();
        this.Hide();
    }
}