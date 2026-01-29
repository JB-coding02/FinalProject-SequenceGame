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

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (!txtUsername.Text.IsWhiteSpace())
            {
                if (!txtPassword.Text.IsWhiteSpace())
                {
                    if (!txtEmail.Text.IsWhiteSpace())
                    {
                        bool UsernameExists = CheckUsername();
                        bool PasswordExists = CheckPassword();
                        bool EmailExists = CheckEmail();
                        if (!UsernameExists && !PasswordExists && !EmailExists)
                        {
                            using (SqlConnection conn = new SqlConnection(getConnectionString()))
                            {
                                conn.Open();
                                string query = $"INSERT INTO PlayerData (Username, Password, PlayerEmail) VALUES ('{txtUsername.Text}', '{txtPassword.Text}', '{txtEmail.Text}')";
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

        public bool CheckUsername()
        {
            bool UsernameMatch = false;
            if (!txtUsername.Text.IsWhiteSpace())
            {
                using (SqlConnection conn = new SqlConnection(getConnectionString()))
                {
                    conn.Open();
                    string query = $"SELECT Username FROM PlayerData WHERE Username = '{txtUsername.Text}'"; // example table
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
                    }
                }
            }
            return UsernameMatch;
        }

        public bool CheckPassword()
        {
            bool PasswordMatch = false;
            if (!txtPassword.Text.IsWhiteSpace())
            {
                using (SqlConnection conn = new SqlConnection(getConnectionString()))
                {
                    conn.Open();
                    string query = $"SELECT Password FROM PlayerData WHERE Password = '{txtPassword.Text}'"; // example table
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["Password"].ToString() == txtPassword.Text)
                        {
                            txtPassword.BackColor = Color.LightGreen;
                            PasswordMatch = true;
                            break;
                        }
                    }
                }
            }
            return PasswordMatch;
        }

        public bool CheckEmail()
        {
            bool EmailMatch = false;
            if (!txtEmail.Text.IsWhiteSpace())
            {
                using (SqlConnection conn = new SqlConnection(getConnectionString()))
                {
                    conn.Open();
                    string query = $"SELECT PlayerEmail FROM PlayerData WHERE PlayerEmail = '{txtEmail.Text}'"; // example table
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["PlayerEmail"].ToString() == txtEmail.Text)
                        {
                            txtEmail.BackColor = Color.LightGreen;
                            EmailMatch = true;
                            break;
                        }
                    }
                }
            }
            return EmailMatch;
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
