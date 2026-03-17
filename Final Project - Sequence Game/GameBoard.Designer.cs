namespace Final_Project___Sequence_Game
{
    partial class GameBoard
    {
        /// <summary>
        /// Designer field.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Frees resources for other uses
        /// </summary>
        /// <param name="disposing">if true its found managed resources that are free to be written over.</param>
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
            picHand0 = new PictureBox();
            picHand1 = new PictureBox();
            picHand2 = new PictureBox();
            picHand3 = new PictureBox();
            picHand4 = new PictureBox();
            picHand5 = new PictureBox();
            picHand6 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picZoomedInBoard).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picHand0).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picHand1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picHand2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picHand3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picHand4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picHand5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picHand6).BeginInit();
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
            // picHand0
            // 
            picHand0.BackColor = Color.Transparent;
            picHand0.BorderStyle = BorderStyle.FixedSingle;
            picHand0.Location = new Point(38, 708);
            picHand0.Name = "picHand0";
            picHand0.Size = new Size(140, 196);
            picHand0.SizeMode = PictureBoxSizeMode.StretchImage;
            picHand0.TabIndex = 10;
            picHand0.TabStop = false;
            picHand0.Click += picHand_Click;
            // 
            // picHand1
            // 
            picHand1.BackColor = Color.Transparent;
            picHand1.BorderStyle = BorderStyle.FixedSingle;
            picHand1.Location = new Point(198, 708);
            picHand1.Name = "picHand1";
            picHand1.Size = new Size(140, 196);
            picHand1.SizeMode = PictureBoxSizeMode.StretchImage;
            picHand1.TabIndex = 11;
            picHand1.TabStop = false;
            picHand1.Click += picHand_Click;
            // 
            // picHand2
            // 
            picHand2.BackColor = Color.Transparent;
            picHand2.BorderStyle = BorderStyle.FixedSingle;
            picHand2.Location = new Point(358, 708);
            picHand2.Name = "picHand2";
            picHand2.Size = new Size(140, 196);
            picHand2.SizeMode = PictureBoxSizeMode.StretchImage;
            picHand2.TabIndex = 12;
            picHand2.TabStop = false;
            picHand2.Click += picHand_Click;
            // 
            // picHand3
            // 
            picHand3.BackColor = Color.Transparent;
            picHand3.BorderStyle = BorderStyle.FixedSingle;
            picHand3.Location = new Point(518, 708);
            picHand3.Name = "picHand3";
            picHand3.Size = new Size(140, 196);
            picHand3.SizeMode = PictureBoxSizeMode.StretchImage;
            picHand3.TabIndex = 13;
            picHand3.TabStop = false;
            picHand3.Click += picHand_Click;
            // 
            // picHand4
            // 
            picHand4.BackColor = Color.Transparent;
            picHand4.BorderStyle = BorderStyle.FixedSingle;
            picHand4.Location = new Point(678, 708);
            picHand4.Name = "picHand4";
            picHand4.Size = new Size(140, 196);
            picHand4.SizeMode = PictureBoxSizeMode.StretchImage;
            picHand4.TabIndex = 14;
            picHand4.TabStop = false;
            picHand4.Click += picHand_Click;
            // 
            // picHand5
            // 
            picHand5.BackColor = Color.Transparent;
            picHand5.BorderStyle = BorderStyle.FixedSingle;
            picHand5.Location = new Point(838, 708);
            picHand5.Name = "picHand5";
            picHand5.Size = new Size(140, 196);
            picHand5.SizeMode = PictureBoxSizeMode.StretchImage;
            picHand5.TabIndex = 15;
            picHand5.TabStop = false;
            picHand5.Click += picHand_Click;
            // 
            // picHand6
            // 
            picHand6.BackColor = Color.Transparent;
            picHand6.BorderStyle = BorderStyle.FixedSingle;
            picHand6.Location = new Point(998, 708);
            picHand6.Name = "picHand6";
            picHand6.Size = new Size(140, 196);
            picHand6.SizeMode = PictureBoxSizeMode.StretchImage;
            picHand6.TabIndex = 16;
            picHand6.TabStop = false;
            picHand6.Click += picHand_Click;
            // 
            // GameBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(192, 192, 0);
            ClientSize = new Size(1177, 924);
            Controls.Add(picHand6);
            Controls.Add(picHand5);
            Controls.Add(picHand4);
            Controls.Add(picHand3);
            Controls.Add(picHand2);
            Controls.Add(picHand1);
            Controls.Add(picHand0);
            ClientSize = new Size(1860, 1186);
            Controls.Add(picZoomedInBoard);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 2, 2, 2);
            Name = "GameBoard";
            Text = "Game Board";
            ((System.ComponentModel.ISupportInitialize)picZoomedInBoard).EndInit();
            ((System.ComponentModel.ISupportInitialize)picHand0).EndInit();
            ((System.ComponentModel.ISupportInitialize)picHand1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picHand2).EndInit();
            ((System.ComponentModel.ISupportInitialize)picHand3).EndInit();
            ((System.ComponentModel.ISupportInitialize)picHand4).EndInit();
            ((System.ComponentModel.ISupportInitialize)picHand5).EndInit();
            ((System.ComponentModel.ISupportInitialize)picHand6).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox picZoomedInBoard;
        private GlowRectangleControl glowRectangleControl2;
        private PictureBox picHand0;
        private PictureBox picHand1;
        private PictureBox picHand2;
        private PictureBox picHand3;
        private PictureBox picHand4;
        private PictureBox picHand5;
        private PictureBox picHand6;

    }
}
