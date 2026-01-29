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
            imgZoomedInBoard = new PictureBox();
            btnCloseZoomedInBoard = new Button();
            ((System.ComponentModel.ISupportInitialize)ImgGameBoard).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgZoomedInBoard).BeginInit();
            SuspendLayout();
            // 
            // ImgGameBoard
            // 
            ImgGameBoard.Image = (Image)resources.GetObject("ImgGameBoard.Image");
            ImgGameBoard.Location = new Point(8, 7);
            ImgGameBoard.Margin = new Padding(2);
            ImgGameBoard.Name = "ImgGameBoard";
            ImgGameBoard.Size = new Size(405, 565);
            ImgGameBoard.SizeMode = PictureBoxSizeMode.AutoSize;
            ImgGameBoard.TabIndex = 0;
            ImgGameBoard.TabStop = false;
            ImgGameBoard.Click += ImgGameBoard_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(428, 7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(521, 64);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // imgZoomedInBoard
            // 
            imgZoomedInBoard.Image = (Image)resources.GetObject("imgZoomedInBoard.Image");
            imgZoomedInBoard.Location = new Point(8, 23);
            imgZoomedInBoard.Name = "imgZoomedInBoard";
            imgZoomedInBoard.Size = new Size(940, 762);
            imgZoomedInBoard.SizeMode = PictureBoxSizeMode.AutoSize;
            imgZoomedInBoard.TabIndex = 2;
            imgZoomedInBoard.TabStop = false;
            imgZoomedInBoard.Visible = false;
            // 
            // btnCloseZoomedInBoard
            // 
            btnCloseZoomedInBoard.Location = new Point(916, 7);
            btnCloseZoomedInBoard.Name = "btnCloseZoomedInBoard";
            btnCloseZoomedInBoard.Size = new Size(32, 23);
            btnCloseZoomedInBoard.TabIndex = 3;
            btnCloseZoomedInBoard.UseVisualStyleBackColor = true;
            btnCloseZoomedInBoard.Visible = false;
            // 
            // GameBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(961, 808);
            Controls.Add(btnCloseZoomedInBoard);
            Controls.Add(imgZoomedInBoard);
            Controls.Add(pictureBox1);
            Controls.Add(ImgGameBoard);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "GameBoard";
            Text = "Game Board";
            ((System.ComponentModel.ISupportInitialize)ImgGameBoard).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgZoomedInBoard).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox ImgGameBoard;
        private PictureBox pictureBox1;
        private PictureBox imgZoomedInBoard;
        private Button btnCloseZoomedInBoard;
    }
}