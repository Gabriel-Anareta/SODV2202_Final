using ChessClient.MVVM.Model;
using ChessClient.MVVM.ViewModel.Commands;
using ChessClient.Net;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ChessClient.MVVM.ViewModel
{
    public class ConnectViewModel : INotifyPropertyChanged
    {
        private Server _server;

        public Action UsersChanged { get; set; } // currently used to u[date the user list

        public List<UserModel> Users { get; set; }

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                if (_username == value)
                    return;
                _username = value;
                OnPropertyChanged(); // notify form elements
                ConnectToServerCommand.NotifyCanExecuteChanged(); // notify ConnectToServerCommand
            }
        }

        private RelayCommand _connectToServerCommand;
        public RelayCommand ConnectToServerCommand
        {
            get { return _connectToServerCommand; }
            set
            {
                if (_connectToServerCommand == value)
                    return;
                _connectToServerCommand = value;
                OnPropertyChanged(); // notify form elements
            }
        }

        public ConnectViewModel()
        {
            _server = new Server();
            _server.ConnectedEvent += UserConnected;

            Users = new List<UserModel>();

            ConnectToServerCommand = new RelayCommand(
                obj => _server.ConnectToServer(Username),
                obj => !string.IsNullOrEmpty(Username)
            );
        }

        public Server GetServer()
            => _server;

        private void UserConnected()
        {
            string username = _server.PacketReader.ReadMessage();
            string uid = _server.PacketReader.ReadMessage();

            if (Users.Any(user => user.UID == uid))
                return;

            Users.Add(new UserModel(username, uid));
            OnUsersChanged();
        }

        private void OnUsersChanged()
            => UsersChanged.Invoke();

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
