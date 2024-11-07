using ChessClient.MVVM.Model;
using ChessClient.MVVM.ViewModel.Commands;
using ChessClient.Net;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ChessClient.MVVM.ViewModel
{
    public class ClientViewModel : INotifyPropertyChanged
    {
        private Server _server;

        public List<UserModel> Users { get; set; }
        public List<string> Messages { get; set; }

        private string _username;
        public string Username
        {
            get { return _username; }
            set {
                if (_username == value) 
                    return;
                _username = value; 
                OnPropertyChanged(); // notify form elements
                ConnectToServerCommand.NotifyCanExecuteChanged(); // notify ConnectToServerCommand
            }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set {
                if (_message == value)
                    return;
                _message = value;
                OnPropertyChanged(); // notify form elements
                SendMessageToServerCommand.NotifyCanExecuteChanged(); // notify SendMessageToServerCommand
            }
        }

        private RelayCommand _sendMessageToServerCommand;
        public RelayCommand SendMessageToServerCommand
        {
            get { return _sendMessageToServerCommand; }
            set { 
                if (_sendMessageToServerCommand == value)
                    return;
                _sendMessageToServerCommand = value;
                OnPropertyChanged(); // notify form elements
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

        public ClientViewModel()
        {
            AppContext.FormClosing += SendDisconnectToServer;
            
            _server = new Server();
            _server.ConnectedEvent += UserConnected;
            _server.MessageRecievedEvent += MessageSent;
            _server.UserDisconnectedEvent += UserDisconnected;

            Users = new List<UserModel>();
            Messages = new List<string>();

            ConnectToServerCommand = new RelayCommand(
                obj => {
                    _server.ConnectToServer(Username);
                    _server.SendMessageToServer($"[{DateTime.Now}]: {Username} has connected!", 5);
                },
                obj => !string.IsNullOrEmpty(Username)
            );

            SendMessageToServerCommand = new RelayCommand(
                obj => _server.SendMessageToServer($"[{Username}]: {Message}", 5),
                obj => !string.IsNullOrEmpty(Message)
            );
        }
        
        private void SendDisconnectToServer(object? sender, EventArgs e)
        {
            _server.SendMessageToServer($"[{DateTime.Now}]: {Username} has disconnected", 10);
        }

        private void UserConnected()
        {
            string username = _server.PacketReader.ReadMessage();
            string uid = _server.PacketReader.ReadMessage();

            if (!Users.Any(user => user.UID == uid))
                return;

            Users.Add(new UserModel(username, uid));
            OnUsersChanged();
        }

        private void MessageSent()
        {
            string message = _server.PacketReader.ReadMessage();
            Messages.Add(message);
            OnMessagesChanged();
        }

        private void UserDisconnected()
        {
            string uid = _server?.PacketReader.ReadMessage();
            UserModel disconnectedUser = Users.Where(user => user.UID == uid).FirstOrDefault();
            Users.Remove(disconnectedUser);
            OnUsersChanged();
        }

        
        public event Action UsersChanged;
        private void OnUsersChanged()
            => UsersChanged?.Invoke();

        public event Action MessagesChanged;
        private void OnMessagesChanged()
            => MessagesChanged?.Invoke();

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
