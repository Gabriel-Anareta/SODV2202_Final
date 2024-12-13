namespace ChessClient.MVVM.View.ConnectLobbies.Controls
{
    public partial class ConnectedUsersDisplay : UserControl
    {
        public Action<string> AddUser { get; set; }
        public Action ClearUsers { get; set; }
        public Action<bool> SetTimer { get; set; }

        private int _periodCount;

        public ConnectedUsersDisplay(int maxSize)
        {
            InitializeComponent();

            lv_ConnectedUsers.StateImageList = new ImageList();
            lv_ConnectedUsers.StateImageList.ImageSize = new Size(1, 35);

            column_empty.ImageIndex = 0;
            column_Users.ImageIndex = 1;
            column_Users.Width = maxSize;
            AddUser += AddItemToList;
            ClearUsers += ClearItems;
            SetTimer += SetPeriodTimer;

            _periodCount = 0;
        }

        private void AddItemToList(string value)
        {
            ListViewItem mockDisplay = new ListViewItem();
            ListViewItem.ListViewSubItem inDisplay = new();
            inDisplay.Text = value;
            mockDisplay.SubItems.Add(inDisplay);

            lv_ConnectedUsers.Items.Add(mockDisplay);
        }

        private void ClearItems()
        {
            lv_ConnectedUsers.Items.Clear();
        }

        private void SetPeriodTimer(bool state)
        {
            if (state)
                timer_period.Start();
            else
                timer_period.Stop();
        }

        private void timer_period_Tick(object sender, EventArgs e)
        {
            _periodCount = _periodCount == 3 ? 0 : _periodCount + 1;
            lbl_UsersConnecting.Text = "Waiting for players";
            for (int i = 0; i < _periodCount; i++)
                lbl_UsersConnecting.Text += " .";
        }
    }
}
