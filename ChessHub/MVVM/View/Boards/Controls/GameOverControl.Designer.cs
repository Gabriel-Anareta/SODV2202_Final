namespace ChessClient.MVVM.View.Boards.Controls
{
    partial class GameOverControl
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
            lbl_GameOver = new Label();
            lbl_EndDetails = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(lbl_EndDetails, 0, 1);
            tableLayoutPanel1.Controls.Add(lbl_GameOver, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(422, 231);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lbl_GameOver
            // 
            lbl_GameOver.AutoSize = true;
            lbl_GameOver.Dock = DockStyle.Fill;
            lbl_GameOver.Font = new Font("Verdana", 15F, FontStyle.Bold);
            lbl_GameOver.ForeColor = Color.FromArgb(255, 192, 128);
            lbl_GameOver.Location = new Point(3, 0);
            lbl_GameOver.Name = "lbl_GameOver";
            lbl_GameOver.Size = new Size(416, 115);
            lbl_GameOver.TabIndex = 2;
            lbl_GameOver.Text = "lbl_GameOver";
            lbl_GameOver.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_EndDetails
            // 
            lbl_EndDetails.AutoSize = true;
            lbl_EndDetails.Dock = DockStyle.Fill;
            lbl_EndDetails.Font = new Font("Verdana", 15F, FontStyle.Bold);
            lbl_EndDetails.ForeColor = Color.FromArgb(255, 192, 128);
            lbl_EndDetails.Location = new Point(3, 115);
            lbl_EndDetails.Name = "lbl_EndDetails";
            lbl_EndDetails.Size = new Size(416, 116);
            lbl_EndDetails.TabIndex = 3;
            lbl_EndDetails.Text = "lbl_EndDetails";
            lbl_EndDetails.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GameOverControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 64, 0);
            Controls.Add(tableLayoutPanel1);
            Name = "GameOverControl";
            Size = new Size(422, 231);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lbl_EndDetails;
        private Label lbl_GameOver;
    }
}
