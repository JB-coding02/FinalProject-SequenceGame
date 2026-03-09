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
            glowRectangleControl2 = new GlowRectangleControl();
            glowRectangleControl1 = new GlowRectangleControl();
            ((System.ComponentModel.ISupportInitialize)picZoomedInBoard).BeginInit();
            SuspendLayout();
            // 
            // picZoomedInBoard
            // 
            picZoomedInBoard.BackColor = Color.White;
            picZoomedInBoard.Image = Properties.Resources.EnlargedGameBoard;
            picZoomedInBoard.Location = new Point(12, 12);
            picZoomedInBoard.Name = "picZoomedInBoard";
            picZoomedInBoard.Size = new Size(1370, 1000);
            picZoomedInBoard.SizeMode = PictureBoxSizeMode.StretchImage;
            picZoomedInBoard.TabIndex = 2;
            picZoomedInBoard.TabStop = false;
            // 
            // glowRectangleControl2
            // 
            glowRectangleControl2.BackColor = Color.Transparent;
            glowRectangleControl2.ForeColor = Color.Transparent;
            glowRectangleControl2.Location = new Point(1227, 101);
            glowRectangleControl2.Name = "glowRectangleControl2";
            glowRectangleControl2.Size = new Size(136, 97);
            glowRectangleControl2.TabIndex = 3;
            // 
            // glowRectangleControl1
            // 
            glowRectangleControl1.BackColor = Color.Transparent;
            glowRectangleControl1.Location = new Point(30, 101);
            glowRectangleControl1.Name = "glowRectangleControl1";
            glowRectangleControl1.Size = new Size(136, 97);
            glowRectangleControl1.TabIndex = 4;
            // 
            // GameBoard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(192, 192, 0);
            ClientSize = new Size(1860, 1186);
            Controls.Add(glowRectangleControl1);
            Controls.Add(glowRectangleControl2);
            Controls.Add(picZoomedInBoard);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GameBoard";
            Text = "Game Board";
            ((System.ComponentModel.ISupportInitialize)picZoomedInBoard).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox picZoomedInBoard;
        private GlowRectangleControl glowRectangleControl2;
        private GlowRectangleControl glowRectangleControl1;
    }
}