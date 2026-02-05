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
            pictureBox1 = new PictureBox();
            picZoomedInBoard = new PictureBox();
            picClose = new PictureBox();
            btnFreeSpace1 = new Button();
            ((System.ComponentModel.ISupportInitialize)ImgGameBoard).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(13, 14);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(521, 64);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
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
            btnFreeSpace1.UseVisualStyleBackColor = true;
            btnFreeSpace1.Visible = false;
            // 
            // GameBoard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 835);
            Controls.Add(picClose);
            Controls.Add(btnFreeSpace1);
            Controls.Add(picZoomedInBoard);
            Controls.Add(pictureBox1);
            Controls.Add(ImgGameBoard);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GameBoard";
            Text = "Game Board";
            ((System.ComponentModel.ISupportInitialize)ImgGameBoard).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picZoomedInBoard).EndInit();
            ((System.ComponentModel.ISupportInitialize)picClose).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox ImgGameBoard;
        private PictureBox pictureBox1;
        private PictureBox picZoomedInBoard;
        private PictureBox picClose;
        private Button btnFreeSpace1;
    }
}