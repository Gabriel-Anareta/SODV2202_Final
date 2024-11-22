namespace ChessClient.MVVM.View.Menu.Controls
{
    partial class Game2PlayerOption
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
            layout_full = new TableLayoutPanel();
            panel_BoardDisplay = new Panel();
            lbl_Title = new Label();
            layout_full.SuspendLayout();
            SuspendLayout();
            // 
            // layout_full
            // 
            layout_full.ColumnCount = 1;
            layout_full.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layout_full.Controls.Add(panel_BoardDisplay, 0, 1);
            layout_full.Controls.Add(lbl_Title, 0, 0);
            layout_full.Dock = DockStyle.Fill;
            layout_full.Location = new Point(0, 0);
            layout_full.Margin = new Padding(0);
            layout_full.Name = "layout_full";
            layout_full.RowCount = 2;
            layout_full.RowStyles.Add(new RowStyle(SizeType.Percent, 27.1062279F));
            layout_full.RowStyles.Add(new RowStyle(SizeType.Percent, 72.8937759F));
            layout_full.Size = new Size(418, 546);
            layout_full.TabIndex = 0;
            // 
            // panel_BoardDisplay
            // 
            panel_BoardDisplay.Anchor = AnchorStyles.None;
            panel_BoardDisplay.Location = new Point(84, 222);
            panel_BoardDisplay.Name = "panel_BoardDisplay";
            panel_BoardDisplay.Size = new Size(250, 250);
            panel_BoardDisplay.TabIndex = 0;
            panel_BoardDisplay.Paint += panel_BoardDisplay_Paint;
            // 
            // lbl_Title
            // 
            lbl_Title.Anchor = AnchorStyles.None;
            lbl_Title.AutoSize = true;
            lbl_Title.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Title.ForeColor = Color.FromArgb(254, 254, 254);
            lbl_Title.Location = new Point(79, 33);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Size = new Size(260, 81);
            lbl_Title.TabIndex = 1;
            lbl_Title.Text = "2 Player";
            lbl_Title.Click += lbl_Title_Click;
            // 
            // Game2PlayerOption
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(140, 52, 18);
            Controls.Add(layout_full);
            Name = "Game2PlayerOption";
            Size = new Size(418, 546);
            layout_full.ResumeLayout(false);
            layout_full.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel layout_full;
        private Panel panel_BoardDisplay;
        private Label lbl_Title;
    }
}
