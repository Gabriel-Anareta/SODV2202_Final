namespace ChessClient.MVVM.View.ConnectLobbies.Controls
{
    partial class ConnectedUsersDisplay
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
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            lbl_UsersConnecting = new Label();
            lv_ConnectedUsers = new ListView();
            column_empty = new ColumnHeader();
            column_Users = new ColumnHeader();
            timer_period = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(lbl_UsersConnecting, 0, 0);
            tableLayoutPanel1.Controls.Add(lv_ConnectedUsers, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 27.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 72.3333359F));
            tableLayoutPanel1.Size = new Size(422, 300);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lbl_UsersConnecting
            // 
            lbl_UsersConnecting.Anchor = AnchorStyles.None;
            lbl_UsersConnecting.AutoSize = true;
            lbl_UsersConnecting.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_UsersConnecting.ForeColor = Color.FromArgb(254, 254, 254);
            lbl_UsersConnecting.Location = new Point(72, 21);
            lbl_UsersConnecting.Name = "lbl_UsersConnecting";
            lbl_UsersConnecting.Size = new Size(277, 41);
            lbl_UsersConnecting.TabIndex = 0;
            lbl_UsersConnecting.Text = "Waiting for players";
            // 
            // lv_ConnectedUsers
            // 
            lv_ConnectedUsers.BackColor = Color.FromArgb(12, 12, 12);
            lv_ConnectedUsers.BorderStyle = BorderStyle.None;
            lv_ConnectedUsers.Columns.AddRange(new ColumnHeader[] { column_empty, column_Users });
            lv_ConnectedUsers.Dock = DockStyle.Fill;
            lv_ConnectedUsers.ForeColor = Color.FromArgb(254, 254, 254);
            lv_ConnectedUsers.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lv_ConnectedUsers.Location = new Point(0, 83);
            lv_ConnectedUsers.Margin = new Padding(0);
            lv_ConnectedUsers.Name = "lv_ConnectedUsers";
            lv_ConnectedUsers.Scrollable = false;
            lv_ConnectedUsers.Size = new Size(422, 217);
            lv_ConnectedUsers.TabIndex = 1;
            lv_ConnectedUsers.UseCompatibleStateImageBehavior = false;
            lv_ConnectedUsers.View = System.Windows.Forms.View.Details;
            // 
            // column_empty
            // 
            column_empty.DisplayIndex = 1;
            column_empty.Text = "";
            column_empty.Width = 0;
            // 
            // column_Users
            // 
            column_Users.DisplayIndex = 0;
            column_Users.Text = "Connected Players";
            column_Users.TextAlign = HorizontalAlignment.Center;
            column_Users.Width = 300;
            // 
            // timer_period
            // 
            timer_period.Interval = 1000;
            timer_period.Tick += timer_period_Tick;
            // 
            // ConnectedUsersDisplay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 12, 12);
            Controls.Add(tableLayoutPanel1);
            Name = "ConnectedUsersDisplay";
            Size = new Size(422, 300);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lbl_UsersConnecting;
        private ListView lv_ConnectedUsers;
        private ColumnHeader column_empty;
        public ColumnHeader column_Users;
        private System.Windows.Forms.Timer timer_period;
    }
}
