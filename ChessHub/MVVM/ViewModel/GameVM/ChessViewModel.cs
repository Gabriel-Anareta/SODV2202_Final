using ChessClient.MVVM.View.Controls;
using ChessClient.MVVM.ViewModel.Commands;
using ChessClient.Net;
using ChessModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ChessClient.MVVM.ViewModel
{
    public abstract class ChessViewModel : INotifyPropertyChanged
    {
        protected Server Server;
        protected PlayerColor ClientColor;
        protected List<string> Users;

        public event PropertyChangedEventHandler? PropertyChanged;
        public Action<Dictionary<Position, Move>> HideHighlights;
        public Action<Dictionary<Position, Move>> ShowHighlights;
        public Action ChoosePromotion;
        public Action<PieceType> PromotionSelected;
        public Action ConfirmPromotion;
        public Action<Result> ShowGameOver;

        public GameState GameState { get; protected set; }
        protected Dictionary<Position, Move> MoveCache;
        protected Position? SelectedPos;
        protected Move? CurrentMove;
        protected bool MenuOnScreen = false;

        private RelayCommand _pieceSelectedCommand;
        public RelayCommand PieceSelectedCommand
        {
            get { return _pieceSelectedCommand; }
            set
            {
                if (_pieceSelectedCommand == value)
                    return;
                _pieceSelectedCommand = value;
                OnPropertyChanged();
            }
        }

        public BindingSource[,] GetBindings()
            => GameState.GameBoard.Pieces.Bindings;

        public bool IsEmpty(Position pos)
            => GameState.GameBoard.IsEmptyPosition(pos);

        protected void PieceSelected(object obj)
        {
            if (MenuOnScreen)
                return;

            BoardSquare square = obj as BoardSquare;
            Position pos = new Position(square.File, square.Rank);

            if (SelectedPos == null)
                OnFromPositionSelected(pos);
            else
                OnToPositionSelected(pos);
        }

        protected void OnFromPositionSelected(Position pos)
        {
            IEnumerable<Move> moves = GameState.ValidMovesFor(pos);
            if (!moves.Any())
                return;

            SelectedPos = pos;
            CacheMoves(moves);
            ShowHighlights.Invoke(MoveCache);
        }

        protected void OnToPositionSelected(Position pos)
        {
            SelectedPos = null;
            HideHighlights.Invoke(MoveCache);
            if (MoveCache.TryGetValue(pos, out Move move))
                if (move.Type == MoveType.PawnPromotion)
                    RaisePromotion(move);
                else
                    HandleMove(move);
        }

        protected void RaisePromotion(Move move)
        {
            CurrentMove = move;
            MenuOnScreen = true;
            ChoosePromotion.Invoke();
        }

        protected void HandleMove(Move move)
        {
            GameState.ExecuteMove(move);
            if (GameState.IsGameOver())
                ShowGameOver(GameState.EndResult);
        }

        protected void CacheMoves(IEnumerable<Move> moves)
        {
            MoveCache.Clear();
            foreach (Move move in moves)
                MoveCache[move.To] = move;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
