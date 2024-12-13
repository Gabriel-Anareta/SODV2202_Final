namespace ChessClient.MVVM.View.ConnectLobbies.Controls
{
    partial class UsernameInput
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
            lbl_Title = new Label();
            tb_UsernameInput = new TextBox();
            btn_Submit = new Button();
            layout_full.SuspendLayout();
            SuspendLayout();
            // 
            // layout_full
            // 
            layout_full.ColumnCount = 1;
            layout_full.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout_full.Controls.Add(lbl_Title, 0, 0);
            layout_full.Controls.Add(tb_UsernameInput, 0, 1);
            layout_full.Controls.Add(btn_Submit, 0, 2);
            layout_full.Dock = DockStyle.Fill;
            layout_full.Location = new Point(0, 0);
            layout_full.Name = "layout_full";
            layout_full.RowCount = 3;
            layout_full.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            layout_full.RowStyles.Add(new RowStyle(SizeType.Percent, 37.9061356F));
            layout_full.RowStyles.Add(new RowStyle(SizeType.Percent, 28.880867F));
            layout_full.Size = new Size(553, 380);
            layout_full.TabIndex = 0;
            // 
            // lbl_Title
            // 
            lbl_Title.Anchor = AnchorStyles.None;
            lbl_Title.AutoSize = true;
            lbl_Title.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Title.ForeColor = Color.FromArgb(254, 254, 254);
            lbl_Title.Location = new Point(159, 44);
            lbl_Title.Margin = new Padding(0);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Size = new Size(235, 38);
            lbl_Title.TabIndex = 0;
            lbl_Title.Text = "Enter your name";
            // 
            // tb_UsernameInput
            // 
            tb_UsernameInput.Anchor = AnchorStyles.None;
            tb_UsernameInput.BorderStyle = BorderStyle.FixedSingle;
            tb_UsernameInput.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_UsernameInput.Location = new Point(131, 178);
            tb_UsernameInput.Margin = new Padding(8);
            tb_UsernameInput.Name = "tb_UsernameInput";
            tb_UsernameInput.Size = new Size(291, 38);
            tb_UsernameInput.TabIndex = 1;
            tb_UsernameInput.Text = "ajksd";
            tb_UsernameInput.TextAlign = HorizontalAlignment.Center;
            // 
            // btn_Submit
            // 
            btn_Submit.Anchor = AnchorStyles.None;
            btn_Submit.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Submit.Location = new Point(171, 299);
            btn_Submit.Name = "btn_Submit";
            btn_Submit.Size = new Size(211, 50);
            btn_Submit.TabIndex = 2;
            btn_Submit.Text = "Connect!";
            btn_Submit.UseVisualStyleBackColor = true;
            btn_Submit.Click += btn_Submit_Click;
            // 
            // UsernameInput
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 12, 12);
            Controls.Add(layout_full);
            Name = "UsernameInput";
            Size = new Size(553, 380);
            layout_full.ResumeLayout(false);
            layout_full.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel layout_full;
        private Label lbl_Title;
        private TextBox tb_UsernameInput;
        private Button btn_Submit;
    }
}
