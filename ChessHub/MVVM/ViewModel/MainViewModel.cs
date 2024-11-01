using ChessClient.MVVM.ViewModel.Commands;
using ChessClient.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ChessClient.MVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private RelayCommand _relayCommand;
        private Server _server;

        public RelayCommand ConnectToServerCommand 
        {
            get { return _relayCommand; }
            set {
                if (_relayCommand == value)
                    return;
                _relayCommand = value;
                OnPropertyChanged(); // notify form elements
            }
        }

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

        public MainViewModel()
        {
            _server = new Server();
            ConnectToServerCommand = new RelayCommand(
                obj => _server.ConnectToServer(Username),
                obj => !string.IsNullOrEmpty(Username)
            );
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
