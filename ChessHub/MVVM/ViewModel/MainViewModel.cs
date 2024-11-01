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
            get => _relayCommand;
            set 
            {
                if (_relayCommand == value)
                    return;
                _relayCommand = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            _server = new Server();
            ConnectToServerCommand = new RelayCommand(_server.ConnectToServer);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
