namespace ChessClient.MVVM.View._2Player
{
    partial class Chess2PlayerView
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
            lbl_PlayerBlack = new Label();
            lbl_PlayerWhite = new Label();
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
            layout_players.ColumnCount = 1;
            layout_players.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout_players.Controls.Add(lbl_PlayerBlack, 0, 1);
            layout_players.Controls.Add(lbl_PlayerWhite, 0, 0);
            layout_players.Dock = DockStyle.Fill;
            layout_players.Location = new Point(400, 0);
            layout_players.Margin = new Padding(0);
            layout_players.Name = "layout_players";
            layout_players.RowCount = 3;
            layout_players.RowStyles.Add(new RowStyle(SizeType.Percent, 17.11111F));
            layout_players.RowStyles.Add(new RowStyle(SizeType.Percent, 18.666666F));
            layout_players.RowStyles.Add(new RowStyle(SizeType.Percent, 64F));
            layout_players.Size = new Size(400, 450);
            layout_players.TabIndex = 1;
            // 
            // lbl_PlayerBlack
            // 
            lbl_PlayerBlack.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_PlayerBlack.AutoSize = true;
            lbl_PlayerBlack.BackColor = Color.FromArgb(12, 12, 12);
            lbl_PlayerBlack.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_PlayerBlack.ForeColor = Color.FromArgb(254, 254, 254);
            lbl_PlayerBlack.Location = new Point(10, 87);
            lbl_PlayerBlack.Margin = new Padding(10);
            lbl_PlayerBlack.Name = "lbl_PlayerBlack";
            lbl_PlayerBlack.Padding = new Padding(10);
            lbl_PlayerBlack.Size = new Size(380, 64);
            lbl_PlayerBlack.TabIndex = 1;
            lbl_PlayerBlack.Text = "Player_Black";
            lbl_PlayerBlack.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_PlayerWhite
            // 
            lbl_PlayerWhite.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_PlayerWhite.AutoSize = true;
            lbl_PlayerWhite.BackColor = Color.FromArgb(254, 254, 254);
            lbl_PlayerWhite.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_PlayerWhite.ForeColor = Color.FromArgb(12, 12, 12);
            lbl_PlayerWhite.Location = new Point(10, 10);
            lbl_PlayerWhite.Margin = new Padding(10);
            lbl_PlayerWhite.Name = "lbl_PlayerWhite";
            lbl_PlayerWhite.Padding = new Padding(10);
            lbl_PlayerWhite.Size = new Size(380, 57);
            lbl_PlayerWhite.TabIndex = 0;
            lbl_PlayerWhite.Text = "Player_White";
            lbl_PlayerWhite.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Chess2PlayerView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(140, 52, 18);
            ClientSize = new Size(800, 450);
            Controls.Add(layout_full);
            Name = "Chess2PlayerView";
            Text = "Chess2PlayerView";
            Load += Chess2PlayerView_Load;
            Resize += Chess2PlayerView_Resize;
            layout_full.ResumeLayout(false);
            layout_players.ResumeLayout(false);
            layout_players.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel layout_full;
        private Panel panel_BoardDisplay;
        private TableLayoutPanel layout_players;
        private Label lbl_PlayerWhite;
        private Label lbl_PlayerBlack;
    }
}