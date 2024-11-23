using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ChessModel
{
    /// <summary>
    /// Implements base piece functionality and properties
    /// </summary>
    public abstract class Piece : INotifyPropertyChanged
    {
        public PieceType Type { get; set; }
        public PlayerColor Color { get; set; }

        private Image _image;
        public Image Image 
        {
            get { return _image; }
            set
            {
                if (_image == value)
                    return;
                _image = value;
                OnPropertyChanged();
            }
        }
        public bool HasMoved { get; set; } = false;

        /// <summary>
        /// Copies the given Piece
        /// </summary>
        /// <returns>A new instance of the respective piece type</returns>
        public abstract Piece Copy();

        /// <summary>
        /// Gets all valid moves a piece can make from their current position
        /// </summary>
        /// <param name="from"></param>
        /// <param name="board"></param>
        /// <returns>An IEnumerable with all the moves piece can make from their current position</returns>
        public abstract IEnumerable<Move> GetMoves(Position from, Board board);

        /// <summary>
        /// Checks if a piece at a position has an opposing king in check
        /// </summary>
        /// <param name="from"></param>
        /// <param name="board"></param>
        /// <returns>True if this piece can capture and opposing king</returns>
        public virtual bool CanCaptureOpponentKing(Position from, Board board, PlayerColor checkColor)
        {
            return GetMoves(from, board)
                .Any(move =>
                    board[move.To] != null
                    && board[move.To].Type == PieceType.King
                    && board[move.To].Color == checkColor
                );
        }

        /// <summary>
        /// Checks all moves in all directions
        /// </summary>
        /// <param name="from"></param>
        /// <param name="board"></param>
        /// <param name="dirs"></param>
        /// <returns>An IEnumerable with all moves in all given directions</returns>
        private protected IEnumerable<Position> MovesInDirections(Position from, Board board, List<Direction> dirs)
            => dirs.SelectMany(dir => MovesInDirection(from, board, dir));
         
        /// <summary>
        /// Checks all moves in a given direction
        /// </summary>
        /// <param name="from"></param>
        /// <param name="board"></param>
        /// <param name="dir"></param>
        /// <returns>An IEnumerable with all moves in a given direction</returns>
        internal IEnumerable<Position> MovesInDirection(Position from, Board board, Direction dir)
        {
            for (Position pos = from + dir; board.IsValidPosition(pos); pos += dir)
            {
                if (board.IsEmptyPosition(pos))
                {
                    yield return pos;
                    continue;
                }

                Piece piece = board[pos];

                if (piece.Color != Color)
                    yield return pos;

                yield break;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
