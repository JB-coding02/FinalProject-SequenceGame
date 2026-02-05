namespace Final_Project___Sequence_Game
{
    partial class GameBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameBoard));
            ImgGameBoard = new PictureBox();
            picJokerRules = new PictureBox();
            picZoomedInBoard = new PictureBox();
            picClose = new PictureBox();
            btnFreeSpace1 = new Button();
            btnFreeSpace2 = new Button();
            ((System.ComponentModel.ISupportInitialize)ImgGameBoard).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picJokerRules).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picZoomedInBoard).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picClose).BeginInit();
            SuspendLayout();
            // 
            // ImgGameBoard
            // 
            ImgGameBoard.Image = (Image)resources.GetObject("ImgGameBoard.Image");
            ImgGameBoard.Location = new Point(13, 86);
            ImgGameBoard.Name = "ImgGameBoard";
            ImgGameBoard.Size = new Size(521, 638);
            ImgGameBoard.TabIndex = 0;
            ImgGameBoard.TabStop = false;
            ImgGameBoard.Click += ImgGameBoard_Click;
            // 
            // picJokerRules
            // 
            picJokerRules.Image = (Image)resources.GetObject("picJokerRules.Image");
            picJokerRules.Location = new Point(13, 14);
            picJokerRules.Margin = new Padding(4, 5, 4, 5);
            picJokerRules.Name = "picJokerRules";
            picJokerRules.Size = new Size(521, 64);
            picJokerRules.SizeMode = PictureBoxSizeMode.AutoSize;
            picJokerRules.TabIndex = 1;
            picJokerRules.TabStop = false;
            // 
            // picZoomedInBoard
            // 
            picZoomedInBoard.Enabled = false;
            picZoomedInBoard.Image = (Image)resources.GetObject("picZoomedInBoard.Image");
            picZoomedInBoard.Location = new Point(12, 12);
            picZoomedInBoard.Name = "picZoomedInBoard";
            picZoomedInBoard.Size = new Size(933, 807);
            picZoomedInBoard.TabIndex = 2;
            picZoomedInBoard.TabStop = false;
            picZoomedInBoard.Visible = false;
            // 
            // picClose
            // 
            picClose.Enabled = false;
            picClose.Image = (Image)resources.GetObject("picClose.Image");
            picClose.Location = new Point(881, 12);
            picClose.Name = "picClose";
            picClose.Size = new Size(64, 64);
            picClose.SizeMode = PictureBoxSizeMode.AutoSize;
            picClose.TabIndex = 3;
            picClose.TabStop = false;
            picClose.Visible = false;
            picClose.Click += picClose_Click;
            // 
            // btnFreeSpace1
            // 
            btnFreeSpace1.BackColor = Color.Transparent;
            btnFreeSpace1.FlatAppearance.BorderColor = Color.Yellow;
            btnFreeSpace1.FlatAppearance.BorderSize = 2;
            btnFreeSpace1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnFreeSpace1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnFreeSpace1.FlatStyle = FlatStyle.Flat;
            btnFreeSpace1.ForeColor = Color.Transparent;
            btnFreeSpace1.Location = new Point(29, 92);
            btnFreeSpace1.Name = "btnFreeSpace1";
            btnFreeSpace1.Size = new Size(86, 67);
            btnFreeSpace1.TabIndex = 4;
            btnFreeSpace1.UseVisualStyleBackColor = false;
            btnFreeSpace1.Visible = false;
            btnFreeSpace1.Click += btnFreeSpace1_Click;
            // 
            // btnFreeSpace2
            // 
            btnFreeSpace2.BackColor = Color.Transparent;
            btnFreeSpace2.FlatAppearance.BorderColor = Color.Yellow;
            btnFreeSpace2.FlatAppearance.BorderSize = 2;
            btnFreeSpace2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnFreeSpace2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnFreeSpace2.FlatStyle = FlatStyle.Flat;
            btnFreeSpace2.ForeColor = Color.Transparent;
            btnFreeSpace2.Location = new Point(844, 92);
            btnFreeSpace2.Name = "btnFreeSpace2";
            btnFreeSpace2.Size = new Size(86, 67);
            btnFreeSpace2.TabIndex = 5;
            btnFreeSpace2.UseVisualStyleBackColor = false;
            btnFreeSpace2.Visible = false;
            btnFreeSpace2.Click += btnFreeSpace2_Click;
            // 
            // GameBoard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 835);
            Controls.Add(btnFreeSpace2);
            Controls.Add(picClose);
            Controls.Add(btnFreeSpace1);
            Controls.Add(picZoomedInBoard);
            Controls.Add(picJokerRules);
            Controls.Add(ImgGameBoard);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GameBoard";
            Text = "Game Board";
            ((System.ComponentModel.ISupportInitialize)ImgGameBoard).EndInit();
            ((System.ComponentModel.ISupportInitialize)picJokerRules).EndInit();
            ((System.ComponentModel.ISupportInitialize)picZoomedInBoard).EndInit();
            ((System.ComponentModel.ISupportInitialize)picClose).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox ImgGameBoard;
        private PictureBox picJokerRules;
        private PictureBox picZoomedInBoard;
        private PictureBox picClose;
        private Button btnFreeSpace1;
        private Button btnFreeSpace2;
    }
}