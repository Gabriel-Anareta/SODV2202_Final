using ChessClient.MVVM.ViewModel.Commands;
using ChessClient.Net;
using ChessModel;

namespace ChessClient.MVVM.ViewModel
{
    public class Chess2PlayerViewModel : ChessViewModel
    {
        private string _usernameWhite;
        public string UsernameWhite
        {
            get { return _usernameWhite; }
            set 
            { 
                if (_usernameWhite == value) 
                    return;
                _usernameWhite = value;
                OnPropertyChanged();
            }
        }

        private string _usernameBlack;
        public string UsernameBlack
        {
            get { return _usernameBlack; }
            set
            {
                if (_usernameBlack == value)
                    return;
                _usernameBlack = value;
                OnPropertyChanged();
            }
        }

        public Chess2PlayerViewModel(PlayerColor color, Server server)
        {
            Server = server;
            Server.MoveRecievedEvent += OnMoveRecieved;
            
            GameState = new GameState2Player(new Board2Player().InitialState(), PlayerColor.White);
            MoveCache = new Dictionary<Position, Move>();
            SelectedPos = null;
            CurrentMove = null;
            ClientColor = color;

            PieceSelectedCommand = new RelayCommand(
                obj => PieceSelected(obj),
                obj =>
                {
                    return ClientColor == GameState.CurrentPlayer;
                }
            );

            PromotionSelected = piece =>
            {
                MenuOnScreen = false;
                ConfirmPromotion.Invoke();
                HandleMove(new PawnPromotion(CurrentMove.From, CurrentMove.To, piece));
            };
        }

        public override void DisplayPlayingUser()
        {
            UsernameBlack = RemovePlaying(UsernameBlack);
            UsernameWhite = RemovePlaying(UsernameWhite);

            switch (GameState.CurrentPlayer)
            {
                case PlayerColor.White:
                    UsernameWhite += " (playing)";
                    break;
                case PlayerColor.Black:
                    UsernameBlack += " (playing)";
                    break;
            }
        }
    }
}
