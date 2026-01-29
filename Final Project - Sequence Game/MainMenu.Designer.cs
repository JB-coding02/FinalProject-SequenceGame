namespace Final_Project___Sequence_Game
{
    partial class MainMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            BtnPlay = new Button();
            lblUsername = new Label();
            txtUsername = new TextBox();
            btnSignIn = new Button();
            btnExitGame = new Button();
            lblPlayerEmail = new Label();
            txtPlayerEmail = new TextBox();
            SuspendLayout();
            // 
            // BtnPlay
            // 
            BtnPlay.Enabled = false;
            BtnPlay.Font = new Font("Segoe UI", 14F);
            BtnPlay.Location = new Point(227, 412);
            BtnPlay.Name = "BtnPlay";
            BtnPlay.Size = new Size(209, 118);
            BtnPlay.TabIndex = 0;
            BtnPlay.Text = "Play";
            BtnPlay.UseVisualStyleBackColor = true;
            BtnPlay.Click += BtnPlay_Click;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 20F);
            lblUsername.Location = new Point(12, 44);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(209, 54);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 20F);
            txtUsername.Location = new Point(227, 41);
            txtUsername.Name = "txtUsername";
            txtUsername.ReadOnly = true;
            txtUsername.Size = new Size(394, 61);
            txtUsername.TabIndex = 2;
            txtUsername.TextAlign = HorizontalAlignment.Center;
            // 
            // btnSignIn
            // 
            btnSignIn.Font = new Font("Segoe UI", 14F);
            btnSignIn.Location = new Point(12, 412);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(209, 118);
            btnSignIn.TabIndex = 3;
            btnSignIn.Text = "Sign-In";
            btnSignIn.UseVisualStyleBackColor = true;
            // 
            // btnExitGame
            // 
            btnExitGame.Font = new Font("Segoe UI", 14F);
            btnExitGame.Location = new Point(442, 412);
            btnExitGame.Name = "btnExitGame";
            btnExitGame.Size = new Size(209, 118);
            btnExitGame.TabIndex = 4;
            btnExitGame.Text = "Exit";
            btnExitGame.UseVisualStyleBackColor = true;
            // 
            // lblPlayerEmail
            // 
            lblPlayerEmail.AutoSize = true;
            lblPlayerEmail.Font = new Font("Segoe UI", 20F);
            lblPlayerEmail.Location = new Point(95, 140);
            lblPlayerEmail.Name = "lblPlayerEmail";
            lblPlayerEmail.Size = new Size(126, 54);
            lblPlayerEmail.TabIndex = 5;
            lblPlayerEmail.Text = "Email:";
            // 
            // txtPlayerEmail
            // 
            txtPlayerEmail.Font = new Font("Segoe UI", 20F);
            txtPlayerEmail.Location = new Point(227, 137);
            txtPlayerEmail.Name = "txtPlayerEmail";
            txtPlayerEmail.ReadOnly = true;
            txtPlayerEmail.Size = new Size(394, 61);
            txtPlayerEmail.TabIndex = 6;
            txtPlayerEmail.TextAlign = HorizontalAlignment.Center;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(660, 540);
            Controls.Add(txtPlayerEmail);
            Controls.Add(lblPlayerEmail);
            Controls.Add(btnExitGame);
            Controls.Add(btnSignIn);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(BtnPlay);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainMenu";
            Text = "Main Menu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnPlay;
        private Label lblUsername;
        private TextBox txtUsername;
        private Button btnSignIn;
        private Button btnExitGame;
        private Label lblPlayerEmail;
        private TextBox txtPlayerEmail;
    }
}
