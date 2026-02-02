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
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(120, 74);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(151, 29);
            txtPassword.TabIndex = 25;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 12F);
            lblPassword.Location = new Point(34, 76);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(79, 21);
            lblPassword.TabIndex = 24;
            lblPassword.Text = "Password:";
            // 
            // btnCreateAccount
            // 
            btnCreateAccount.Location = new Point(8, 166);
            btnCreateAccount.Margin = new Padding(2, 2, 2, 2);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.Size = new Size(284, 53);
            btnCreateAccount.TabIndex = 23;
            btnCreateAccount.Text = "Create Account";
            btnCreateAccount.UseVisualStyleBackColor = true;
            btnCreateAccount.Click += btnCreateAccount_Click;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.Location = new Point(120, 39);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(151, 29);
            txtEmail.TabIndex = 21;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 12F);
            lblEmail.Location = new Point(62, 41);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(51, 21);
            lblEmail.TabIndex = 20;
            lblEmail.Text = "Email:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.Location = new Point(120, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(151, 29);
            txtUsername.TabIndex = 19;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 12F);
            lblUsername.Location = new Point(27, 5);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(84, 21);
            lblUsername.TabIndex = 18;
            lblUsername.Text = "Username:";
            // 
            // lblReEnterPassword
            // 
            lblReEnterPassword.AutoSize = true;
            lblReEnterPassword.Font = new Font("Segoe UI", 9F);
            lblReEnterPassword.Location = new Point(3, 116);
            lblReEnterPassword.Name = "lblReEnterPassword";
            lblReEnterPassword.Size = new Size(107, 15);
            lblReEnterPassword.TabIndex = 26;
            lblReEnterPassword.Text = "Confirm Password:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.Location = new Point(120, 111);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(151, 29);
            textBox1.TabIndex = 27;
            // 
            // CreateAccount
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 226);
            Controls.Add(textBox1);
            Controls.Add(lblReEnterPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(btnCreateAccount);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Margin = new Padding(2, 2, 2, 2);
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
        private TextBox textBox1;
    }
}