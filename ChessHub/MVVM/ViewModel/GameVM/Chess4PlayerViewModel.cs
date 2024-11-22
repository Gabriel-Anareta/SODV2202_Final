using ChessClient.MVVM.ViewModel.Commands;
using ChessClient.Net;
using ChessModel;

namespace ChessClient.MVVM.ViewModel
{
    public class Chess4PlayerViewModel : ChessViewModel
    {
        public Chess4PlayerViewModel(PlayerColor color, Server server)
        {
            Server = server;
            
            GameState = new GameState4Player(new Board4Player().InitialState(), color);
            MoveCache = new Dictionary<Position, Move>();
            SelectedPos = null;
            CurrentMove = null;
            ClientColor = color;

            PieceSelectedCommand = new RelayCommand(
                obj => PieceSelected(obj),
                obj => ClientColor == GameState.CurrentPlayer
            );

            PromotionSelected = piece =>
            {
                MenuOnScreen = false;
                ConfirmPromotion.Invoke();
                HandleMove(new PawnPromotion(CurrentMove.From, CurrentMove.To, piece));
            };
        }

        public bool IsDeadSpace(int file, int rank)
            => ((Board4Player)GameState.GameBoard).PositionInDeadSpace(new Position(file, rank));
    }
}
