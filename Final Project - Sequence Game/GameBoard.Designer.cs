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
            ((System.ComponentModel.ISupportInitialize)ImgGameBoard).BeginInit();
            SuspendLayout();
            // 
            // ImgGameBoard
            // 
            ImgGameBoard.Image = (Image)resources.GetObject("ImgGameBoard.Image");
            ImgGameBoard.Location = new Point(8, 7);
            ImgGameBoard.Margin = new Padding(2, 2, 2, 2);
            ImgGameBoard.Name = "ImgGameBoard";
            ImgGameBoard.Size = new Size(800, 644);
            ImgGameBoard.SizeMode = PictureBoxSizeMode.AutoSize;
            ImgGameBoard.TabIndex = 0;
            ImgGameBoard.TabStop = false;
            // 
            // GameBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(961, 808);
            Controls.Add(ImgGameBoard);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 2, 2, 2);
            Name = "GameBoard";
            Text = "Game Board";
            ((System.ComponentModel.ISupportInitialize)ImgGameBoard).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox ImgGameBoard;
    }
}