using ChessClient.MVVM.View.ConnectLobbies.Controls;
using ChessClient.MVVM.ViewModel;
using ChessClient.Net;

namespace ChessClient.MVVM.View.ConnectLobbies
{
    public partial class ConnectingLobby : Form
    {
        public Action<Server, string> PlayerConnected { get; set; }
        
        private ConnectViewModel viewModel;
        private UsernameInput usernameInput;
        private ConnectedUsersDisplay connectedUsers;

        public ConnectingLobby()
        {
            InitializeComponent();

            viewModel = new ConnectViewModel();
            viewModel.UsersChanged += UpdateUserList;

            usernameInput = new UsernameInput(viewModel);
            usernameInput.Dock = DockStyle.Fill;
            usernameInput.UsernameSubmitted += ShowConnectedUsers;
            usernameInput.SetEnabled(true);

            connectedUsers = new ConnectedUsersDisplay(this.ClientSize.Width);
            connectedUsers.Dock = DockStyle.Fill;
            connectedUsers.SetEnabled(false);
        }

        private void ConnectingLobby_Load(object sender, EventArgs e)
        {
            Controls.Add(usernameInput);
            Controls.Add(connectedUsers);
        }

        private void ShowConnectedUsers()
        {
            usernameInput.SetEnabled(false);
            connectedUsers.SetEnabled(true);
            StartTimer();
            OnPlayerConnected(viewModel.GetServer());
        }

        private void UpdateUserList()
        {
            this.InvokeOnThread(() =>
            {
                ClearUsers();
                foreach (var user in viewModel.Users)
                    AddUser(user.Username);
            });
        }

        private void AddUser(string username)
            => connectedUsers.AddUser.Invoke(username);

        private void ClearUsers()
            => connectedUsers.ClearUsers.Invoke();

        public void StartTimer()
            => connectedUsers.SetTimer(true);

        public void StopTimer()
            => connectedUsers.SetTimer(false);

        private void OnPlayerConnected(Server server)
            => PlayerConnected.Invoke(server, viewModel.Username);
    }
}
