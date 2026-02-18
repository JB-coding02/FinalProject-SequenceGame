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
            txtEmail.Location = new Point(106, 50);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(151, 29);
            txtEmail.TabIndex = 12;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 12F);
            lblEmail.Location = new Point(47, 52);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(51, 21);
            lblEmail.TabIndex = 11;
            lblEmail.Text = "Email:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.Location = new Point(106, 15);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(151, 29);
            txtUsername.TabIndex = 10;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 12F);
            lblUsername.Location = new Point(12, 15);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(84, 21);
            lblUsername.TabIndex = 9;
            lblUsername.Text = "Username:";
            // 
            // btnSignIn
            // 
            btnSignIn.Location = new Point(8, 127);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(247, 53);
            btnSignIn.TabIndex = 13;
            btnSignIn.Text = "Sign In";
            btnSignIn.UseVisualStyleBackColor = true;
            btnSignIn.Click += btnSignIn_Click;
            // 
            // btnCreateAccount
            // 
            btnCreateAccount.Location = new Point(8, 192);
            btnCreateAccount.Margin = new Padding(2, 2, 2, 2);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.Size = new Size(247, 53);
            btnCreateAccount.TabIndex = 15;
            btnCreateAccount.Text = "Create Account";
            btnCreateAccount.UseVisualStyleBackColor = true;
            btnCreateAccount.Click += btnCreateAccount_Click;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 12F);
            lblPassword.Location = new Point(19, 88);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(79, 21);
            lblPassword.TabIndex = 16;
            lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(106, 86);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(151, 29);
            txtPassword.TabIndex = 17;
            // 
            // SignIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(265, 252);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(btnCreateAccount);
            Controls.Add(btnSignIn);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
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