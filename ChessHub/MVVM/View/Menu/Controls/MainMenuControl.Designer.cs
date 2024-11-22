namespace ChessClient.MVVM.View.Menu.Controls
{
    partial class MainMenuControl
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
            lbl_Start = new Label();
            lbl_Title = new Label();
            lbl_Help = new Label();
            layout_full.SuspendLayout();
            SuspendLayout();
            // 
            // layout_full
            // 
            layout_full.ColumnCount = 1;
            layout_full.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout_full.Controls.Add(lbl_Start, 0, 1);
            layout_full.Controls.Add(lbl_Title, 0, 0);
            layout_full.Controls.Add(lbl_Help, 0, 2);
            layout_full.Dock = DockStyle.Fill;
            layout_full.Location = new Point(0, 0);
            layout_full.Margin = new Padding(0);
            layout_full.Name = "layout_full";
            layout_full.RowCount = 4;
            layout_full.RowStyles.Add(new RowStyle(SizeType.Percent, 52.19298F));
            layout_full.RowStyles.Add(new RowStyle(SizeType.Percent, 23.68421F));
            layout_full.RowStyles.Add(new RowStyle(SizeType.Percent, 24.1228065F));
            layout_full.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            layout_full.Size = new Size(640, 364);
            layout_full.TabIndex = 0;
            // 
            // lbl_Start
            // 
            lbl_Start.Anchor = AnchorStyles.None;
            lbl_Start.AutoSize = true;
            lbl_Start.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Start.ForeColor = Color.FromArgb(254, 254, 254);
            lbl_Start.Location = new Point(265, 169);
            lbl_Start.Margin = new Padding(0);
            lbl_Start.Name = "lbl_Start";
            lbl_Start.Size = new Size(109, 54);
            lbl_Start.TabIndex = 1;
            lbl_Start.Text = "Start";
            lbl_Start.TextAlign = ContentAlignment.MiddleCenter;
            lbl_Start.Click += lbl_Start_Click;
            // 
            // lbl_Title
            // 
            lbl_Title.AutoSize = true;
            lbl_Title.Dock = DockStyle.Fill;
            lbl_Title.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Title.ForeColor = Color.FromArgb(254, 254, 254);
            lbl_Title.Location = new Point(0, 0);
            lbl_Title.Margin = new Padding(0);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Size = new Size(640, 160);
            lbl_Title.TabIndex = 0;
            lbl_Title.Text = "Chess Hub";
            lbl_Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Help
            // 
            lbl_Help.Anchor = AnchorStyles.None;
            lbl_Help.AutoSize = true;
            lbl_Help.BackColor = Color.Transparent;
            lbl_Help.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Help.ForeColor = Color.FromArgb(254, 254, 254);
            lbl_Help.Location = new Point(266, 242);
            lbl_Help.Name = "lbl_Help";
            lbl_Help.Size = new Size(107, 54);
            lbl_Help.TabIndex = 2;
            lbl_Help.Text = "Help";
            lbl_Help.Click += lbl_Help_Click;
            // 
            // MainMenuControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(layout_full);
            Name = "MainMenuControl";
            Size = new Size(640, 364);
            layout_full.ResumeLayout(false);
            layout_full.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel layout_full;
        private Label lbl_Start;
        private Label lbl_Title;
        private Label lbl_Help;
    }
}
