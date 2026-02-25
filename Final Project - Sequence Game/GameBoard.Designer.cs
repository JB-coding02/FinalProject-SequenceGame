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
            picZoomedInBoard = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picZoomedInBoard).BeginInit();
            SuspendLayout();
            // 
            // picZoomedInBoard
            // 
            picZoomedInBoard.BackColor = Color.Transparent;
            picZoomedInBoard.Image = Properties.Resources.EnlargedGameBoard;
            picZoomedInBoard.Location = new Point(8, 7);
            picZoomedInBoard.Margin = new Padding(2, 2, 2, 2);
            picZoomedInBoard.Name = "picZoomedInBoard";
            picZoomedInBoard.Size = new Size(1114, 900);
            picZoomedInBoard.SizeMode = PictureBoxSizeMode.AutoSize;
            picZoomedInBoard.TabIndex = 2;
            picZoomedInBoard.TabStop = false;
            // 
            // GameBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 0);
            ClientSize = new Size(1177, 924);
            Controls.Add(picZoomedInBoard);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 2, 2, 2);
            Name = "GameBoard";
            Text = "Game Board";
            ((System.ComponentModel.ISupportInitialize)picZoomedInBoard).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox picZoomedInBoard;
    }
}