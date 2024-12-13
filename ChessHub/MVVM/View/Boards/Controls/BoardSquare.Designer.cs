namespace ChessClient.MVVM.View.Controls
{
    partial class BoardSquare
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pb_PieceImg = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pb_PieceImg).BeginInit();
            SuspendLayout();
            // 
            // pb_PieceImg
            // 
            pb_PieceImg.BackColor = Color.Transparent;
            pb_PieceImg.Dock = DockStyle.Fill;
            pb_PieceImg.Location = new Point(0, 0);
            pb_PieceImg.Name = "pb_PieceImg";
            pb_PieceImg.Size = new Size(150, 150);
            pb_PieceImg.SizeMode = PictureBoxSizeMode.Zoom;
            pb_PieceImg.TabIndex = 0;
            pb_PieceImg.TabStop = false;
            pb_PieceImg.Click += pb_PieceImg_Click;
            // 
            // BoardSquare
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(pb_PieceImg);
            Name = "BoardSquare";
            ((System.ComponentModel.ISupportInitialize)pb_PieceImg).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pb_PieceImg;
    }
}
