using ChessClient.MVVM.View;
using ChessClient.MVVM.View._2Player;
using ChessClient.MVVM.View._4Player;
using ChessClient.MVVM.View.ConnectLobbies;
using ChessClient.MVVM.View.Menu;
using ChessClient.MVVM.View.ViewUtils;
using ChessClient.Net;
using ChessModel;

namespace ChessClient
{
    public class AppContext : ApplicationContext
    {
        private Server _appServer;
        
        private MainMenuView _mainMenu;
        private List<ConnectingLobby> _connectionLobbies;
        private List<Server> _servers;
        private List<Form> _gameBoards;
        private BoardType _selectedType;
        private int _requiredUsers;

        private List<PlayerColor> _player4Colors = new List<PlayerColor>
        {
            PlayerColor.Red,
            PlayerColor.Green,
            PlayerColor.Yellow,
            PlayerColor.Blue
        };
        private List<PlayerColor> _player2Colors = new List<PlayerColor>
        {
            PlayerColor.White,
            PlayerColor.Black
        };


        public AppContext()
        {
            _appServer = new Server();
            _appServer.StartGameEvent += CreateGames;
            _appServer.ConnectToServer("App Context");

            _servers = new List<Server>();
            _gameBoards = new List<Form>();
            
            _mainMenu = new MainMenuView();
            _mainMenu.CreateGame += OpenConnectionLobbies;
            _mainMenu.Show();
        }

        private void OpenConnectionLobbies(BoardType type)
        {
            _mainMenu.Close();
            _connectionLobbies = new List<ConnectingLobby>();
            _selectedType = type;
            
            switch (_selectedType) 
            {
                case BoardType.Board2Player:
                    _requiredUsers = 2;
                    break;
                case BoardType.Board4Player:
                    _requiredUsers = 4;
                    break;
            }

            _appServer.SendMessageToServer(_requiredUsers.ToString(), 20);

            for (int i = 0; i < _requiredUsers; i++)
            {
                ConnectingLobby lobby = new ConnectingLobby();
                lobby.PlayerConnected += StoreServers;
                _connectionLobbies.Add(lobby);
            }

            foreach (ConnectingLobby lobby in _connectionLobbies)
                lobby.Show();
        }

        private void StoreServers(Server server)
            => _servers.Add(server);

        private void CreateGames()
        {
            Task waitForServers = Task.Run(() =>
            {
                while (_servers.Count < _requiredUsers) { }
            });

            waitForServers.Wait();

            for (int i = 0; i < _requiredUsers; i++)
            {
                switch (_selectedType)
                {
                    case BoardType.Board2Player:
                        _gameBoards.Add(new Chess2PlayerView(_player2Colors[i], _servers[i]));
                        break;
                    case BoardType.Board4Player:
                        _gameBoards.Add(new Chess4PlayerView(_player4Colors[i], _servers[i]));
                        break;
                }
            }

            foreach (ConnectingLobby lobby in _connectionLobbies)
                lobby.InvokeOnThread(() => 
                {
                    lobby.StopTimer();
                    lobby.Close();
                });

            foreach (Form game in _gameBoards)
                game.Show();
        }
    }
}
