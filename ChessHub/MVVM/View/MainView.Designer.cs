namespace ChessHub
{
    partial class MainView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            lb_Users = new ListBox();
            tb_Username = new TextBox();
            clientViewModelBindingSource = new BindingSource(components);
            btn_Connect = new Button();
            lb_Messages = new ListBox();
            btn_Send = new Button();
            rtb_message = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)clientViewModelBindingSource).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(lb_Users);
            splitContainer1.Panel1.Controls.Add(tb_Username);
            splitContainer1.Panel1.Controls.Add(btn_Connect);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(lb_Messages);
            splitContainer1.Panel2.Controls.Add(btn_Send);
            splitContainer1.Panel2.Controls.Add(rtb_message);
            splitContainer1.Size = new Size(782, 453);
            splitContainer1.SplitterDistance = 225;
            splitContainer1.SplitterWidth = 1;
            splitContainer1.TabIndex = 0;
            // 
            // lb_Users
            // 
            lb_Users.FormattingEnabled = true;
            lb_Users.Location = new Point(0, 61);
            lb_Users.Name = "lb_Users";
            lb_Users.Size = new Size(229, 384);
            lb_Users.TabIndex = 3;
            // 
            // tb_Username
            // 
            tb_Username.DataBindings.Add(new Binding("Text", clientViewModelBindingSource, "Username", true, DataSourceUpdateMode.OnPropertyChanged));
            tb_Username.Location = new Point(0, 0);
            tb_Username.Margin = new Padding(0);
            tb_Username.Name = "tb_Username";
            tb_Username.Size = new Size(229, 27);
            tb_Username.TabIndex = 2;
            // 
            // clientViewModelBindingSource
            // 
            clientViewModelBindingSource.DataSource = typeof(ChessClient.MVVM.ViewModel.ClientViewModel);
            // 
            // btn_Connect
            // 
            btn_Connect.BackColor = Color.Silver;
            btn_Connect.DataBindings.Add(new Binding("Command", clientViewModelBindingSource, "ConnectToServerCommand", true));
            btn_Connect.FlatStyle = FlatStyle.Flat;
            btn_Connect.ForeColor = Color.White;
            btn_Connect.Location = new Point(0, 27);
            btn_Connect.Margin = new Padding(0);
            btn_Connect.Name = "btn_Connect";
            btn_Connect.Size = new Size(229, 34);
            btn_Connect.TabIndex = 1;
            btn_Connect.Text = "Connect";
            btn_Connect.UseVisualStyleBackColor = false;
            // 
            // lb_Messages
            // 
            lb_Messages.FormattingEnabled = true;
            lb_Messages.Location = new Point(0, 0);
            lb_Messages.Name = "lb_Messages";
            lb_Messages.Size = new Size(556, 384);
            lb_Messages.TabIndex = 3;
            // 
            // btn_Send
            // 
            btn_Send.BackColor = Color.Silver;
            btn_Send.DataBindings.Add(new Binding("Command", clientViewModelBindingSource, "SendMessageToServerCommand", true));
            btn_Send.FlatStyle = FlatStyle.Flat;
            btn_Send.ForeColor = Color.White;
            btn_Send.Location = new Point(459, 396);
            btn_Send.Margin = new Padding(0);
            btn_Send.Name = "btn_Send";
            btn_Send.RightToLeft = RightToLeft.Yes;
            btn_Send.Size = new Size(97, 57);
            btn_Send.TabIndex = 2;
            btn_Send.Text = "Send";
            btn_Send.UseVisualStyleBackColor = false;
            // 
            // rtb_message
            // 
            rtb_message.DataBindings.Add(new Binding("Text", clientViewModelBindingSource, "Message", true, DataSourceUpdateMode.OnPropertyChanged));
            rtb_message.Location = new Point(0, 396);
            rtb_message.Margin = new Padding(0);
            rtb_message.Name = "rtb_message";
            rtb_message.Size = new Size(459, 57);
            rtb_message.TabIndex = 1;
            rtb_message.Text = "";
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 453);
            Controls.Add(splitContainer1);
            Name = "MainView";
            Text = "Main View";
            Load += MainView_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)clientViewModelBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button btn_Connect;
        private Button btn_Send;
        private RichTextBox rtb_message;
        private TextBox tb_Username;
        private BindingSource clientViewModelBindingSource;
        private DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn uIDDataGridViewTextBoxColumn;
        private ListBox lb_Users;
        private ListBox lb_Messages;
    }
}
