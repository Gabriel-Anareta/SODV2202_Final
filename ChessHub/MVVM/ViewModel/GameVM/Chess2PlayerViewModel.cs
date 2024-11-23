using ChessClient.MVVM.ViewModel.Commands;
using ChessClient.Net;
using ChessModel;

namespace ChessClient.MVVM.ViewModel
{
    public class Chess2PlayerViewModel : ChessViewModel
    {
        public string UsernameWhite { get; set; }
        public string UsernameBlack { get; set; }

        public Chess2PlayerViewModel(PlayerColor color, Server server)
        {
            Server = server;
            
            GameState = new GameState2Player(new Board2Player().InitialState(), PlayerColor.White);
            MoveCache = new Dictionary<Position, Move>();
            SelectedPos = null;
            CurrentMove = null;
            ClientColor = color;

            PieceSelectedCommand = new RelayCommand(
                obj => PieceSelected(obj)
                //obj => ClientColor == GameState.CurrentPlayer
            );

            PromotionSelected = piece =>
            {
                MenuOnScreen = false;
                ConfirmPromotion.Invoke();
                HandleMove(new PawnPromotion(CurrentMove.From, CurrentMove.To, piece));
            };
        }
    }
}
