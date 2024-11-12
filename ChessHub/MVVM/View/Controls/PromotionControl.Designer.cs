namespace ChessClient.MVVM.View.Controls
{
    partial class PromotionControl
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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            pb_Queen = new PictureBox();
            pb_Rook = new PictureBox();
            pb_Knight = new PictureBox();
            pb_Bishop = new PictureBox();
            pb_Pawn = new PictureBox();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Queen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_Rook).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_Knight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_Bishop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_Pawn).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50.5952377F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 49.4047623F));
            tableLayoutPanel1.Size = new Size(409, 172);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 5;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.Controls.Add(pb_Queen, 0, 0);
            tableLayoutPanel2.Controls.Add(pb_Rook, 1, 0);
            tableLayoutPanel2.Controls.Add(pb_Knight, 2, 0);
            tableLayoutPanel2.Controls.Add(pb_Bishop, 3, 0);
            tableLayoutPanel2.Controls.Add(pb_Pawn, 4, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 90);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(403, 79);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // pb_Queen
            // 
            pb_Queen.Dock = DockStyle.Fill;
            pb_Queen.Location = new Point(3, 3);
            pb_Queen.Name = "pb_Queen";
            pb_Queen.Size = new Size(74, 73);
            pb_Queen.TabIndex = 0;
            pb_Queen.TabStop = false;
            pb_Queen.Click += Piece_Click;
            // 
            // pb_Rook
            // 
            pb_Rook.Dock = DockStyle.Fill;
            pb_Rook.Location = new Point(83, 3);
            pb_Rook.Name = "pb_Rook";
            pb_Rook.Size = new Size(74, 73);
            pb_Rook.TabIndex = 1;
            pb_Rook.TabStop = false;
            pb_Rook.Click += Piece_Click;
            // 
            // pb_Knight
            // 
            pb_Knight.Dock = DockStyle.Fill;
            pb_Knight.Location = new Point(163, 3);
            pb_Knight.Name = "pb_Knight";
            pb_Knight.Size = new Size(74, 73);
            pb_Knight.TabIndex = 2;
            pb_Knight.TabStop = false;
            pb_Knight.Click += Piece_Click;
            // 
            // pb_Bishop
            // 
            pb_Bishop.Dock = DockStyle.Fill;
            pb_Bishop.Location = new Point(243, 3);
            pb_Bishop.Name = "pb_Bishop";
            pb_Bishop.Size = new Size(74, 73);
            pb_Bishop.TabIndex = 3;
            pb_Bishop.TabStop = false;
            pb_Bishop.Click += Piece_Click;
            // 
            // pb_Pawn
            // 
            pb_Pawn.Dock = DockStyle.Fill;
            pb_Pawn.Location = new Point(323, 3);
            pb_Pawn.Name = "pb_Pawn";
            pb_Pawn.Size = new Size(77, 73);
            pb_Pawn.TabIndex = 4;
            pb_Pawn.TabStop = false;
            pb_Pawn.Click += Piece_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Verdana", 15F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(255, 192, 128);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(403, 87);
            label1.TabIndex = 1;
            label1.Text = "Choose A Piece";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PromotionControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 64, 0);
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(tableLayoutPanel1);
            Name = "PromotionControl";
            Size = new Size(409, 172);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb_Queen).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_Rook).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_Knight).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_Bishop).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_Pawn).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private PictureBox pb_Queen;
        private PictureBox pb_Rook;
        private PictureBox pb_Knight;
        private PictureBox pb_Bishop;
        private PictureBox pb_Pawn;
        private Label label1;
    }
}
