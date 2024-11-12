namespace ChessModel.Views
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
            pb_Img = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pb_Img).BeginInit();
            SuspendLayout();
            // 
            // pb_Img
            // 
            pb_Img.BackColor = Color.Transparent;
            pb_Img.Dock = DockStyle.Fill;
            pb_Img.Location = new Point(0, 0);
            pb_Img.Name = "pb_Img";
            pb_Img.Size = new Size(150, 150);
            pb_Img.SizeMode = PictureBoxSizeMode.Zoom;
            pb_Img.TabIndex = 0;
            pb_Img.TabStop = false;
            pb_Img.Click += pb_Img_Click;
            // 
            // BoardSquare
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(pb_Img);
            Name = "BoardSquare";
            ((System.ComponentModel.ISupportInitialize)pb_Img).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pb_Img;
    }
}
