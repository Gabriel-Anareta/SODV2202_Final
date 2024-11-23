namespace ChessClient.MVVM.View._4Player
{
    partial class Chess4PlayerView
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
            layout_full = new TableLayoutPanel();
            panel_BoardDisplay = new Panel();
            layout_players = new TableLayoutPanel();
            lbl_ScoreBlue = new Label();
            lbl_ScoreYellow = new Label();
            lbl_ScoreGreen = new Label();
            lbl_ScoreRed = new Label();
            lbl_PlayerBlue = new Label();
            lbl_PlayerYellow = new Label();
            lbl_PlayerGreen = new Label();
            lbl_PlayerRed = new Label();
            layout_full.SuspendLayout();
            layout_players.SuspendLayout();
            SuspendLayout();
            // 
            // layout_full
            // 
            layout_full.ColumnCount = 2;
            layout_full.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layout_full.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layout_full.Controls.Add(panel_BoardDisplay, 0, 0);
            layout_full.Controls.Add(layout_players, 1, 0);
            layout_full.Dock = DockStyle.Fill;
            layout_full.Location = new Point(0, 0);
            layout_full.Name = "layout_full";
            layout_full.RowCount = 1;
            layout_full.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout_full.Size = new Size(800, 450);
            layout_full.TabIndex = 0;
            // 
            // panel_BoardDisplay
            // 
            panel_BoardDisplay.Anchor = AnchorStyles.None;
            panel_BoardDisplay.Location = new Point(0, 25);
            panel_BoardDisplay.Margin = new Padding(0);
            panel_BoardDisplay.Name = "panel_BoardDisplay";
            panel_BoardDisplay.Size = new Size(400, 400);
            panel_BoardDisplay.TabIndex = 0;
            // 
            // layout_players
            // 
            layout_players.ColumnCount = 2;
            layout_players.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 69.75F));
            layout_players.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.25F));
            layout_players.Controls.Add(lbl_ScoreBlue, 1, 3);
            layout_players.Controls.Add(lbl_ScoreYellow, 1, 2);
            layout_players.Controls.Add(lbl_ScoreGreen, 1, 1);
            layout_players.Controls.Add(lbl_ScoreRed, 1, 0);
            layout_players.Controls.Add(lbl_PlayerBlue, 0, 3);
            layout_players.Controls.Add(lbl_PlayerYellow, 0, 2);
            layout_players.Controls.Add(lbl_PlayerGreen, 0, 1);
            layout_players.Controls.Add(lbl_PlayerRed, 0, 0);
            layout_players.Dock = DockStyle.Fill;
            layout_players.Location = new Point(400, 0);
            layout_players.Margin = new Padding(0);
            layout_players.Name = "layout_players";
            layout_players.RowCount = 4;
            layout_players.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            layout_players.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            layout_players.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            layout_players.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            layout_players.Size = new Size(400, 450);
            layout_players.TabIndex = 1;
            // 
            // lbl_ScoreBlue
            // 
            lbl_ScoreBlue.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_ScoreBlue.AutoSize = true;
            lbl_ScoreBlue.BackColor = Color.Transparent;
            lbl_ScoreBlue.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_ScoreBlue.ForeColor = Color.FromArgb(254, 254, 254);
            lbl_ScoreBlue.Location = new Point(289, 346);
            lbl_ScoreBlue.Margin = new Padding(10);
            lbl_ScoreBlue.Name = "lbl_ScoreBlue";
            lbl_ScoreBlue.Size = new Size(101, 94);
            lbl_ScoreBlue.TabIndex = 10;
            lbl_ScoreBlue.Text = "BlueScore";
            lbl_ScoreBlue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_ScoreYellow
            // 
            lbl_ScoreYellow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_ScoreYellow.AutoSize = true;
            lbl_ScoreYellow.BackColor = Color.Transparent;
            lbl_ScoreYellow.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_ScoreYellow.ForeColor = Color.FromArgb(254, 254, 254);
            lbl_ScoreYellow.Location = new Point(289, 234);
            lbl_ScoreYellow.Margin = new Padding(10);
            lbl_ScoreYellow.Name = "lbl_ScoreYellow";
            lbl_ScoreYellow.Size = new Size(101, 92);
            lbl_ScoreYellow.TabIndex = 9;
            lbl_ScoreYellow.Text = "RedScore";
            lbl_ScoreYellow.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_ScoreGreen
            // 
            lbl_ScoreGreen.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_ScoreGreen.AutoSize = true;
            lbl_ScoreGreen.BackColor = Color.Transparent;
            lbl_ScoreGreen.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_ScoreGreen.ForeColor = Color.FromArgb(254, 254, 254);
            lbl_ScoreGreen.Location = new Point(289, 122);
            lbl_ScoreGreen.Margin = new Padding(10);
            lbl_ScoreGreen.Name = "lbl_ScoreGreen";
            lbl_ScoreGreen.Size = new Size(101, 92);
            lbl_ScoreGreen.TabIndex = 8;
            lbl_ScoreGreen.Text = "RedScore";
            lbl_ScoreGreen.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_ScoreRed
            // 
            lbl_ScoreRed.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_ScoreRed.AutoSize = true;
            lbl_ScoreRed.BackColor = Color.Transparent;
            lbl_ScoreRed.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_ScoreRed.ForeColor = Color.FromArgb(254, 254, 254);
            lbl_ScoreRed.Location = new Point(289, 10);
            lbl_ScoreRed.Margin = new Padding(10);
            lbl_ScoreRed.Name = "lbl_ScoreRed";
            lbl_ScoreRed.Size = new Size(101, 92);
            lbl_ScoreRed.TabIndex = 7;
            lbl_ScoreRed.Text = "RedScore";
            lbl_ScoreRed.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_PlayerBlue
            // 
            lbl_PlayerBlue.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_PlayerBlue.AutoSize = true;
            lbl_PlayerBlue.BackColor = Color.Blue;
            lbl_PlayerBlue.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_PlayerBlue.ForeColor = Color.FromArgb(254, 254, 254);
            lbl_PlayerBlue.Location = new Point(10, 346);
            lbl_PlayerBlue.Margin = new Padding(10);
            lbl_PlayerBlue.Name = "lbl_PlayerBlue";
            lbl_PlayerBlue.Padding = new Padding(10);
            lbl_PlayerBlue.Size = new Size(259, 94);
            lbl_PlayerBlue.TabIndex = 6;
            lbl_PlayerBlue.Text = "lbl_Blue";
            lbl_PlayerBlue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_PlayerYellow
            // 
            lbl_PlayerYellow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_PlayerYellow.AutoSize = true;
            lbl_PlayerYellow.BackColor = Color.Yellow;
            lbl_PlayerYellow.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_PlayerYellow.ForeColor = Color.FromArgb(254, 254, 254);
            lbl_PlayerYellow.Location = new Point(10, 234);
            lbl_PlayerYellow.Margin = new Padding(10);
            lbl_PlayerYellow.Name = "lbl_PlayerYellow";
            lbl_PlayerYellow.Padding = new Padding(10);
            lbl_PlayerYellow.Size = new Size(259, 92);
            lbl_PlayerYellow.TabIndex = 4;
            lbl_PlayerYellow.Text = "lbl_Yellow";
            lbl_PlayerYellow.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_PlayerGreen
            // 
            lbl_PlayerGreen.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_PlayerGreen.AutoSize = true;
            lbl_PlayerGreen.BackColor = Color.Green;
            lbl_PlayerGreen.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_PlayerGreen.ForeColor = Color.FromArgb(254, 254, 254);
            lbl_PlayerGreen.Location = new Point(10, 122);
            lbl_PlayerGreen.Margin = new Padding(10);
            lbl_PlayerGreen.Name = "lbl_PlayerGreen";
            lbl_PlayerGreen.Padding = new Padding(10);
            lbl_PlayerGreen.Size = new Size(259, 92);
            lbl_PlayerGreen.TabIndex = 2;
            lbl_PlayerGreen.Text = "lbl_Green";
            lbl_PlayerGreen.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_PlayerRed
            // 
            lbl_PlayerRed.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_PlayerRed.AutoSize = true;
            lbl_PlayerRed.BackColor = Color.Red;
            lbl_PlayerRed.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_PlayerRed.ForeColor = Color.FromArgb(254, 254, 254);
            lbl_PlayerRed.Location = new Point(10, 10);
            lbl_PlayerRed.Margin = new Padding(10);
            lbl_PlayerRed.Name = "lbl_PlayerRed";
            lbl_PlayerRed.Padding = new Padding(10);
            lbl_PlayerRed.Size = new Size(259, 92);
            lbl_PlayerRed.TabIndex = 0;
            lbl_PlayerRed.Text = "lbl_Red";
            lbl_PlayerRed.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Chess4PlayerView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(140, 52, 18);
            ClientSize = new Size(800, 450);
            Controls.Add(layout_full);
            Name = "Chess4PlayerView";
            Text = "Chess4PlayerView";
            Load += Chess4PlayerView_Load;
            Resize += Chess4PlayerView_Resize;
            layout_full.ResumeLayout(false);
            layout_players.ResumeLayout(false);
            layout_players.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel layout_full;
        private Panel panel_BoardDisplay;
        private TableLayoutPanel layout_players;
        private Label lbl_PlayerRed;
        private Label lbl_ScoreBlue;
        private Label lbl_ScoreYellow;
        private Label lbl_ScoreGreen;
        private Label lbl_ScoreRed;
        private Label lbl_PlayerBlue;
        private Label lbl_PlayerYellow;
        private Label lbl_PlayerGreen;
    }
}