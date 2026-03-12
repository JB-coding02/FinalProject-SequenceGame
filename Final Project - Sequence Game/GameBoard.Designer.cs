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
            // GameBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 0);
            ClientSize = new Size(1177, 924);
            Controls.Add(picZoomedInBoard);

            // Hand picture boxes (7), centered horizontally and docked visually above other controls
            // Card size uses 2.5:3.5 width:height ratio -> height = width * 1.4
            int handCardWidth = 140;
            int handCardHeight = (int)(handCardWidth * 1.4); // 196
            int handSpacing = 20;
            int totalHandWidth = (7 * handCardWidth) + (6 * handSpacing);
            int startX = (this.ClientSize.Width - totalHandWidth) / 2;
            int startY = this.ClientSize.Height - handCardHeight - 20; // 20 px bottom margin

            PictureBox[] handPics = new PictureBox[] { picHand0, picHand1, picHand2, picHand3, picHand4, picHand5, picHand6 };
            for (int i = 0; i < handPics.Length; i++)
            {
                var pb = handPics[i];
                pb.Location = new Point(startX + i * (handCardWidth + handSpacing), startY);
                pb.Name = "picHand" + i;
                pb.Size = new Size(handCardWidth, handCardHeight);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.TabIndex = 10 + i;
                pb.TabStop = false;
                pb.BorderStyle = BorderStyle.FixedSingle;
                pb.BackColor = Color.Transparent;
                pb.Click += new EventHandler(picHand_Click);
                Controls.Add(pb);
                pb.BringToFront();
            }
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
