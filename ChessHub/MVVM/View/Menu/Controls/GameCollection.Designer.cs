namespace ChessClient.MVVM.View.Menu.Controls
{
    partial class GameCollection
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
            player2Option = new Game2PlayerOption();
            player4Option = new Game4PlayerOption();
            layout_full.SuspendLayout();
            SuspendLayout();
            // 
            // layout_full
            // 
            layout_full.ColumnCount = 2;
            layout_full.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layout_full.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layout_full.Controls.Add(player2Option, 0, 0);
            layout_full.Controls.Add(player4Option, 1, 0);
            layout_full.Dock = DockStyle.Fill;
            layout_full.Location = new Point(0, 0);
            layout_full.Margin = new Padding(0);
            layout_full.Name = "layout_full";
            layout_full.RowCount = 1;
            layout_full.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout_full.Size = new Size(780, 442);
            layout_full.TabIndex = 0;
            // 
            // player2Option
            // 
            player2Option.BackColor = Color.FromArgb(140, 52, 18);
            player2Option.Dock = DockStyle.Fill;
            player2Option.Location = new Point(10, 10);
            player2Option.Margin = new Padding(10, 10, 5, 10);
            player2Option.Name = "player2Option";
            player2Option.Selected = null;
            player2Option.Size = new Size(375, 422);
            player2Option.TabIndex = 0;
            // 
            // player4Option
            // 
            player4Option.BackColor = Color.FromArgb(140, 52, 18);
            player4Option.Dock = DockStyle.Fill;
            player4Option.Location = new Point(395, 10);
            player4Option.Margin = new Padding(5, 10, 10, 10);
            player4Option.Name = "player4Option";
            player4Option.Selected = null;
            player4Option.Size = new Size(375, 422);
            player4Option.TabIndex = 1;
            // 
            // GameCollection
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(254, 254, 254);
            Controls.Add(layout_full);
            Name = "GameCollection";
            Size = new Size(780, 442);
            layout_full.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel layout_full;
        private Game2PlayerOption player2Option;
        private Game4PlayerOption player4Option;
    }
}
