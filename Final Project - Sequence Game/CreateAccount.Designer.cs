namespace Final_Project___Sequence_Game
{
    partial class CreateAccount
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
            txtPassword = new TextBox();
            lblPassword = new Label();
            btnCreateAccount = new Button();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            lblReEnterPassword = new Label();
            txtConfirmPass = new TextBox();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(171, 123);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(214, 39);
            txtPassword.TabIndex = 25;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 12F);
            lblPassword.Location = new Point(49, 127);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(116, 32);
            lblPassword.TabIndex = 24;
            lblPassword.Text = "Password:";
            // 
            // btnCreateAccount
            // 
            btnCreateAccount.Location = new Point(11, 277);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.Size = new Size(406, 88);
            btnCreateAccount.TabIndex = 23;
            btnCreateAccount.Text = "Create Account";
            btnCreateAccount.UseVisualStyleBackColor = true;
            btnCreateAccount.Click += btnCreateAccount_Click;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.Location = new Point(171, 65);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(214, 39);
            txtEmail.TabIndex = 21;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 12F);
            lblEmail.Location = new Point(89, 68);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(76, 32);
            lblEmail.TabIndex = 20;
            lblEmail.Text = "Email:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.Location = new Point(171, 7);
            txtUsername.Margin = new Padding(4, 5, 4, 5);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(214, 39);
            txtUsername.TabIndex = 19;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 12F);
            lblUsername.Location = new Point(39, 8);
            lblUsername.Margin = new Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(126, 32);
            lblUsername.TabIndex = 18;
            lblUsername.Text = "Username:";
            // 
            // lblReEnterPassword
            // 
            lblReEnterPassword.AutoSize = true;
            lblReEnterPassword.Font = new Font("Segoe UI", 9F);
            lblReEnterPassword.Location = new Point(4, 193);
            lblReEnterPassword.Margin = new Padding(4, 0, 4, 0);
            lblReEnterPassword.Name = "lblReEnterPassword";
            lblReEnterPassword.Size = new Size(160, 25);
            lblReEnterPassword.TabIndex = 26;
            lblReEnterPassword.Text = "Confirm Password:";
            // 
            // txtConfirmPass
            // 
            txtConfirmPass.Font = new Font("Segoe UI", 12F);
            txtConfirmPass.Location = new Point(171, 185);
            txtConfirmPass.Margin = new Padding(4, 5, 4, 5);
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.Size = new Size(214, 39);
            txtConfirmPass.TabIndex = 27;
            // 
            // CreateAccount
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(429, 377);
            Controls.Add(txtConfirmPass);
            Controls.Add(lblReEnterPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(btnCreateAccount);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Name = "CreateAccount";
            Text = "Create Account";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPassword;
        private Label lblPassword;
        private Button btnCreateAccount;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtUsername;
        private Label lblUsername;
        private Label lblReEnterPassword;
        private TextBox txtConfirmPass;
    }
}