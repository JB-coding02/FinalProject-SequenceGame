using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Final_Project___Sequence_Game
{
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
            if (!txtUsername.Text.IsWhiteSpace())
            {
                if (!txtPassword.Text.IsWhiteSpace())
                {
                    if (!txtEmail.Text.IsWhiteSpace())
                    {
                        bool UsernameExists = CheckUsername();
                        bool EmailExists = CheckEmail();
                        if (!UsernameExists && !EmailExists)
                        {
                            using (SqlConnection conn = new SqlConnection(getConnectionString()))
                            {
                                conn.Open();
                                string query = 
                                    $"""
                                    INSERT INTO PlayerData 
                                    (Username, Password, PlayerEmail) 
                                    VALUES ('{txtUsername.Text}',
                                    '{txtPassword.Text}',
                                    '{txtEmail.Text}')
                                    """;
                                SqlCommand cmd = new SqlCommand(query, conn);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Account created successfully!");
                                this.Hide();
                                SignIn signInForm = new SignIn();
                                signInForm.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("One or more of the entered details already exist. Please try again with different details.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter an email.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a password.");
                }

            }
            else
            {
                MessageBox.Show("Please enter a username.");
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
            bool UsernameMatch = true;
            if (!txtUsername.Text.IsWhiteSpace())
            {
                using (SqlConnection conn = new SqlConnection(getConnectionString()))
                {
                    conn.Open();
                    string query = 
                        $"""
                        SELECT Username 
                        FROM PlayerData 
                        WHERE Username = '{txtUsername.Text}'
                        """;
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["Username"].ToString() != txtUsername.Text)
                        {
                            UsernameMatch = false;
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
        /// Checks if the entered password matches one in the database.
        /// </summary>
        /// <returns>True if the entered password matches a stored 
        /// password for an account, but returns false if it doesn't match</returns>
        public bool CheckPassword()
        {
            bool PasswordMatch = true;
            if (!txtPassword.Text.IsWhiteSpace())
            {
                using (SqlConnection conn = new SqlConnection(getConnectionString()))
                {
                    conn.Open();
                    string PasswordQuery = $"""
                        SELECT PasswordHash 
                        FROM PlayerData 
                        WHERE PasswordHash = '{txtPassword.Text}'
                        """;
                    SqlCommand PasswordCmd = new SqlCommand(PasswordQuery, conn);
                    SqlDataReader PasswordReader = PasswordCmd.ExecuteReader();

                    while (PasswordReader.Read())
                    {
                        if (PasswordReader["Password"].ToString() == txtPassword.Text)
                        {
                            PasswordMatch = false;
                            txtPassword.BackColor = Color.LightGreen;
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
        /// <returns>True if the entered Email matches a stored 
        /// Email for an account, but returns false if it doesn't match</returns>
        public bool CheckEmail()
        {
            bool EmailMatch = true;
            if (!txtEmail.Text.IsWhiteSpace())
            {
                using (SqlConnection conn = GetSqlConnection())
                {
                    conn.Open();
                    string EmailQuery = $"""
                        SELECT PlayerEmail 
                        FROM PlayerData 
                        WHERE PlayerEmail = '{txtEmail.Text}'
                        """;
                    SqlCommand EmailCmd = new SqlCommand(EmailQuery, conn);
                    SqlDataReader EmailReader = EmailCmd.ExecuteReader();

                    while (EmailReader.Read())
                    {
                        if (EmailReader["PlayerEmail"].ToString() == txtEmail.Text)
                        {
                            EmailMatch = false;
                            txtEmail.BackColor = Color.LightGreen;
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
    }
}
