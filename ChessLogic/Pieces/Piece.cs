using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel
{
    /// <summary>
    /// Implements base piece functionality and properties
    /// </summary>
    public abstract class Piece
    {
        public abstract PieceType Type { get; }
        public abstract PlayerColor Color { get; }
        public bool HasMoved { get; set; } = false;

        /// <summary>
        /// Copies the given Piece
        /// </summary>
        /// <returns>A new instance of the respective piece type</returns>
        public abstract Piece Copy();

        public abstract IEnumerable<Move> GetMoves(Position from, Board board);

        /// <summary>
        /// Checks if a piece at a position has an opposing king in check
        /// </summary>
        /// <param name="from"></param>
        /// <param name="board"></param>
        /// <returns>True if this piece can capture and opposing king</returns>
        public virtual bool CanCaptureOpponentKing(Position from, Board board)
        {
            return GetMoves(from, board)
                .Any(move =>
                    board[move.To] != null
                    && board[move.To].Type == PieceType.King
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
    }
}
