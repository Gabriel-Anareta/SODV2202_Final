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

        public Action<Move> MoveExecuted;
        public Action<string> MoveScheduled;
        public Action CurrentPlayerChanged;

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

        private void OnCurrentPlayerChanged()
            => CurrentPlayerChanged?.Invoke();

        public abstract void DisplayPlayingUser();

        public string RemovePlaying(string username)
            => username.Replace("(playing)", string.Empty).Trim();

        protected void OnMoveRecieved()
        {
            string move = Server.PacketReader.ReadMessage();

            string[] moveArgs = move.Split('-');
            Position from = Position.ToPosition(moveArgs[0]);
            if (GameState.GameBoard[from].Type == PieceType.None)
                return;

            OnMoveScheduled(move);
            //HandleMove(move);
        }

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
                    OnMoveExecuted(move);
                    //HandleMove(move);
        }

        protected void OnPromotionSelected(PieceType piece)
        {
            MenuOnScreen = false;
            ConfirmPromotion.Invoke();
            OnMoveExecuted(new PawnPromotion(CurrentMove.From, CurrentMove.To, piece));
            //HandleMove(new PawnPromotion(CurrentMove.From, CurrentMove.To, piece));
        }

        protected void RaisePromotion(Move move)
        {
            CurrentMove = move;
            MenuOnScreen = true;
            ChoosePromotion.Invoke();
        }

        private void OnMoveExecuted(Move move)
            => MoveExecuted?.Invoke(move);

        private void OnMoveScheduled(string move)
            => MoveScheduled.Invoke(move);

        public void HandleMove(string move)
        {
            GameState.ExecuteMove(move);
            OnCurrentPlayerChanged();
            if (GameState.IsGameOver())
                ShowGameOver(GameState.EndResult);
        }

        public void HandleMove(Move move)
        {
            GameState.ExecuteMove(move);
            OnCurrentPlayerChanged();
            Server.SendMessageToServer(move.ToString(), 2);
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
