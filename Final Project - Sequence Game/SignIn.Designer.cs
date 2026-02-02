namespace Final_Project___Sequence_Game
{
    partial class SignIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            btnSignIn = new Button();
            btnCreateAccount = new Button();
            lblPassword = new Label();
            txtPassword = new TextBox();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.Location = new Point(151, 84);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(214, 39);
            txtEmail.TabIndex = 12;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 12F);
            lblEmail.Location = new Point(67, 87);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(76, 32);
            lblEmail.TabIndex = 11;
            lblEmail.Text = "Email:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.Location = new Point(151, 25);
            txtUsername.Margin = new Padding(4, 5, 4, 5);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(214, 39);
            txtUsername.TabIndex = 10;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 12F);
            lblUsername.Location = new Point(17, 25);
            lblUsername.Margin = new Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(126, 32);
            lblUsername.TabIndex = 9;
            lblUsername.Text = "Username:";
            // 
            // btnSignIn
            // 
            btnSignIn.Enabled = false;
            btnSignIn.Location = new Point(12, 211);
            btnSignIn.Margin = new Padding(4, 5, 4, 5);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(353, 88);
            btnSignIn.TabIndex = 13;
            btnSignIn.Text = "Sign In";
            btnSignIn.UseVisualStyleBackColor = true;
            btnSignIn.Click += btnSignIn_Click;
            // 
            // btnCreateAccount
            // 
            btnCreateAccount.Location = new Point(11, 320);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.Size = new Size(353, 88);
            btnCreateAccount.TabIndex = 15;
            btnCreateAccount.Text = "Create Account";
            btnCreateAccount.UseVisualStyleBackColor = true;
            btnCreateAccount.Click += btnCreateAccount_Click;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 12F);
            lblPassword.Location = new Point(27, 146);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(116, 32);
            lblPassword.TabIndex = 16;
            lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(151, 143);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(214, 39);
            txtPassword.TabIndex = 17;
            // 
            // SignIn
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(378, 420);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(btnCreateAccount);
            Controls.Add(btnSignIn);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Margin = new Padding(4, 5, 4, 5);
            Name = "SignIn";
            Text = "Sign-In";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtUsername;
        private Label lblUsername;
        private Button btnSignIn;
        private Button btnCreateAccount;
        private Label lblPassword;
        private TextBox txtPassword;
    }
}