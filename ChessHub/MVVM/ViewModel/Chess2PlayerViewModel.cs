using ChessClient.MVVM.View.Controls;
using ChessClient.MVVM.ViewModel.Commands;
using ChessClient.Net;
using ChessModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ChessClient.MVVM.ViewModel
{
    public class Chess2PlayerViewModel : INotifyPropertyChanged
    {
        private Server _server;
        private PlayerColor _clientColor;

        public event PropertyChangedEventHandler? PropertyChanged;
        public Action<Dictionary<Position, Move>> HideHighlights;
        public Action<Dictionary<Position, Move>> ShowHighlights;
        public Action<PlayerColor> ChoosePromotion;
        public Action<PieceType> PromotionSelected;
        public Action ConfirmPromotion;
        public Action ShowGameOver;

        private readonly GameState2Player _gameState;
        private readonly Dictionary<Position, Move> _moveCache;
        private Position? _selectedPos;
        private Move? _currentMove;
        private bool _menuOnScreen = false;

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

        public Chess2PlayerViewModel(PlayerColor color)
        {
            _gameState = new GameState2Player(new Board2Player().InitialState(), PlayerColor.White);
            _moveCache = new Dictionary<Position, Move>();
            _selectedPos = null;
            _currentMove = null;
            _clientColor = color;

            PieceSelectedCommand = new RelayCommand(
                obj => PieceSelected(obj),
                obj => _clientColor == _gameState.CurrentPlayer
            );

            PromotionSelected = piece =>
            {
                _menuOnScreen = false;
                ConfirmPromotion.Invoke();
                HandleMove(new PawnPromotion(_currentMove.From, _currentMove.To, piece));
            };
        }

        public BindingSource[,] GetBindings()
            => _gameState.GameBoard.Pieces.Bindings;

        public bool IsEmpty(Position pos)
            => _gameState.GameBoard.IsEmptyPosition(pos);

        private void PieceSelected(object obj)
        {
            if (_menuOnScreen)
                return;
            
            BoardSquare square = obj as BoardSquare;
            Position pos = new Position(square.File, square.Rank);

            if (_selectedPos == null)
                OnFromPositionSelected(pos);
            else
                OnToPositionSelected(pos);
        }

        private void OnFromPositionSelected(Position pos)
        {
            IEnumerable<Move> moves = _gameState.ValidMovesFor(pos);
            if (!moves.Any())
                return;

            _selectedPos = pos;
            CacheMoves(moves);
            ShowHighlights.Invoke(_moveCache);
        }

        private void OnToPositionSelected(Position pos)
        {
            _selectedPos = null;
            HideHighlights.Invoke(_moveCache);
            if (_moveCache.TryGetValue(pos, out Move move))
                if (move.Type == MoveType.PawnPromotion)
                    RaisePromotion(move);
                else
                    HandleMove(move);
        }

        private void RaisePromotion(Move move)
        {
            _currentMove = move;
            _menuOnScreen = true;
            ChoosePromotion.Invoke(_clientColor);
        }

        private void HandleMove(Move move)
        {
            _gameState.ExecuteMove(move);
            //if (_gameState.IsGameOver())
            //    ShowGameOver(_gameState.EndResult);
        }

        private void CacheMoves(IEnumerable<Move> moves)
        {
            _moveCache.Clear();
            foreach (Move move in moves)
                _moveCache[move.To] = move;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
