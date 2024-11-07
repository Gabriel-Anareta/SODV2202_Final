using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel
{
    /// <summary>
    /// Represents a king - implements piece
    /// </summary>
    /// <param name="color"></param>
    public class King(PlayerColor color) : Piece
    {
        public override PieceType Type => PieceType.King;
        public override PlayerColor Color { get; } = color;

        private static readonly List<Direction> _allDirections = new List<Direction>
        {
            Direction.North,
            Direction.East,
            Direction.South,
            Direction.West,
            Direction.NorthEast,
            Direction.NorthWest,
            Direction.SouthEast,
            Direction.SouthWest
        };

        public override Piece Copy()
        {
            King copy = new King(this.Color);
            copy.HasMoved = this.HasMoved;
            return copy;
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            foreach (Position pos in ValidMoves(from, board))
            {
                yield return new NormalMove(from, pos);
            }
        }

        public override bool CanCaptureOpponentKing(Position from, Board board)
        {
            return ValidMoves(from, board)
                .Any(pos =>
                    board[pos] != null
                    && board[pos].Type == PieceType.King
                );
        }

        private IEnumerable<Position> ValidMoves(Position pos, Board board)
        {
            foreach (Direction dir in _allDirections)
            {
                Position to = pos + dir;

                if (!board.IsValidPosition(to))
                    continue;

                if (board.IsEmptyPosition(pos) || board[pos].Color == Color)
                    yield return to;
            }
        }
    }
}
