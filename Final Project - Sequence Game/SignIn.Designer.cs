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
            txtEmailOrPhone = new TextBox();
            lblEmail = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            btnSignIn = new Button();
            SuspendLayout();
            // 
            // txtEmailOrPhone
            // 
            txtEmailOrPhone.Location = new Point(143, 55);
            txtEmailOrPhone.Name = "txtEmailOrPhone";
            txtEmailOrPhone.Size = new Size(100, 23);
            txtEmailOrPhone.TabIndex = 12;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(12, 58);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(125, 15);
            lblEmail.TabIndex = 11;
            lblEmail.Text = "Email/Phone Number:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(143, 12);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(100, 23);
            txtUsername.TabIndex = 10;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(12, 15);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(63, 15);
            lblUsername.TabIndex = 9;
            lblUsername.Text = "Username:";
            // 
            // btnSignIn
            // 
            btnSignIn.Location = new Point(12, 284);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(247, 53);
            btnSignIn.TabIndex = 13;
            btnSignIn.Text = "Sign In";
            btnSignIn.UseVisualStyleBackColor = true;
            // 
            // SignIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(271, 349);
            Controls.Add(btnSignIn);
            Controls.Add(txtEmailOrPhone);
            Controls.Add(lblEmail);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Name = "SignIn";
            Text = "SignIn";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmailOrPhone;
        private Label lblEmail;
        private TextBox txtUsername;
        private Label lblUsername;
        private Button btnSignIn;
    }
}