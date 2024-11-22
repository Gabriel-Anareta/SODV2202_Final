using ChessClient.MVVM.View.Menu;
using ChessClient.MVVM.View.ViewUtils;

namespace ChessClient
{
    public class AppContext : ApplicationContext
    {
        private MainMenuView _mainMenu;
        private List<Form> _connectionLobbies;

        public AppContext()
        {
            _mainMenu = new MainMenuView();
            _mainMenu.CreateGame += OpenConnectionLobbies;
            _mainMenu.Show();
        }

        private void OpenConnectionLobbies(BoardType type)
        {
            _mainMenu.Close();
            _connectionLobbies = new List<Form>();
            
            switch (type) 
            {
                case BoardType.Board2Player:
                    break;
                case BoardType.Board4Player:
                    break;
            }

            foreach (Form lobby in _connectionLobbies)
                lobby.Show();
        }
    }
}
