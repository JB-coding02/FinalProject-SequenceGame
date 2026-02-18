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
            // Validate inputs first
            if (!ValidateInputs(out string username, out string password, out string email))
                return;

            // Check uniqueness
            bool usernameExists = CheckUsernameExists(username);
            bool emailExists = CheckEmailExists(email);

            if (usernameExists)
            {
                MessageBox.Show("Username already exists. Please choose a different username.");
                txtUsername.BackColor = Color.DarkRed;
                return;
            }

            if (emailExists)
            {
                MessageBox.Show("An account with this email already exists.");
                txtEmail.BackColor = Color.DarkRed;
                return;
            }

            // All checks passed, create the account
            PassedChecks(username, password, email);
        }

        private bool ValidateInputs(out string username, out string password, out string email)
        {
            username = txtUsername.Text?.Trim() ?? string.Empty;
            password = txtPassword.Text?.Trim() ?? string.Empty;
            email = txtEmail.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter a username.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter a password.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter an email.");
                return false;
            }

            try
            {
                // Basic email validation
                var _ = new System.Net.Mail.MailAddress(email);
            }
            catch
            {
                MessageBox.Show("Please enter a valid email address.");
                return false;
            }

            return true;
        }

        private void PassedChecks(string username, string password, string email)
        {
            using (SqlConnection conn = GetSqlConnection())
            {
                conn.Open();
                const string insertSql = @"INSERT INTO PlayerData (Username, PasswordHash, PlayerEmail) VALUES (@username, @password, @email);";
                using SqlCommand cmd = new SqlCommand(insertSql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Account created successfully!");
            this.Hide();
            SignIn signInForm = new SignIn();
            signInForm.Show();
        }

        /// <summary>
        /// Checks if the entered Username matches 
        /// another Username stored in the database.
        /// </summary>
        /// <returns>True if the entered Username matches a stored 
        /// Username for an account, but returns false if it doesn't match</returns>
        /// <summary>
        /// Returns true when the username already exists in the database.
        /// </summary>
        public bool CheckUsernameExists(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;

            using (SqlConnection conn = GetSqlConnection())
            {
                conn.Open();
                const string sql = "SELECT COUNT(1) FROM PlayerData WHERE Username = @username";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
        /// <summary>
        /// Checks if the entered password matches one in the database.
        /// </summary>
        /// <returns>True if the entered password matches a stored 
        /// password for an account, but returns false if it doesn't match</returns>
        /// <summary>
        /// Returns true if the supplied password exists in the database (compares against PasswordHash column).
        /// Note: This function performs a direct string comparison against the stored value.
        /// </summary>
        public bool CheckPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            using (SqlConnection conn = GetSqlConnection())
            {
                conn.Open();
                const string sql = "SELECT COUNT(1) FROM PlayerData WHERE PasswordHash = @password";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@password", password);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        /// <summary>
        /// Checks if the entered Email matches 
        /// another Email stored in the database.
        /// </summary>
        /// <returns>True if the entered Email matches a stored 
        /// Email for an account, but returns false if it doesn't match</returns>
        /// <summary>
        /// Returns true when the email already exists in the database.
        /// </summary>
        public bool CheckEmailExists(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            using (SqlConnection conn = GetSqlConnection())
            {
                conn.Open();
                const string sql = "SELECT COUNT(1) FROM PlayerData WHERE PlayerEmail = @email";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@email", email);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
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
    }
}
