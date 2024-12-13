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
            layout_full.SuspendLayout();
            SuspendLayout();
            // 
            // layout_full
            // 
            layout_full.ColumnCount = 1;
            layout_full.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout_full.Controls.Add(lbl_Start, 0, 1);
            layout_full.Controls.Add(lbl_Title, 0, 0);
            layout_full.Dock = DockStyle.Fill;
            layout_full.Location = new Point(0, 0);
            layout_full.Margin = new Padding(0);
            layout_full.Name = "layout_full";
            layout_full.RowCount = 3;
            layout_full.RowStyles.Add(new RowStyle(SizeType.Percent, 52.19298F));
            layout_full.RowStyles.Add(new RowStyle(SizeType.Percent, 32.9670334F));
            layout_full.RowStyles.Add(new RowStyle(SizeType.Percent, 15.10989F));
            layout_full.Size = new Size(1111, 541);
            layout_full.TabIndex = 0;
            // 
            // lbl_Start
            // 
            lbl_Start.Anchor = AnchorStyles.None;
            lbl_Start.AutoSize = true;
            lbl_Start.Font = new Font("Segoe UI Semibold", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Start.ForeColor = Color.FromArgb(254, 254, 254);
            lbl_Start.Location = new Point(487, 336);
            lbl_Start.Margin = new Padding(0);
            lbl_Start.Name = "lbl_Start";
            lbl_Start.Size = new Size(137, 67);
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
            lbl_Title.Size = new Size(1111, 281);
            lbl_Title.TabIndex = 0;
            lbl_Title.Text = "Chess Hub";
            lbl_Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainMenuControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(layout_full);
            Name = "MainMenuControl";
            Size = new Size(1111, 541);
            layout_full.ResumeLayout(false);
            layout_full.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel layout_full;
        private Label lbl_Start;
        private Label lbl_Title;
    }
}
