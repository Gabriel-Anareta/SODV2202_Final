using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel
{
    /// <summary>
    /// Represents a queen - implements piece
    /// </summary>
    /// <param name="color"></param>
    public class Queen(PlayerColor color) : Piece
    {
        public override PieceType Type => PieceType.Queen;
        public override PlayerColor Color { get; } = color;

        private static readonly List<Direction> Directions = new List<Direction>
        {
            Direction.North,
            Direction.South,
            Direction.East,
            Direction.West,
            Direction.NorthEast,
            Direction.NorthWest,
            Direction.SouthEast,
            Direction.SouthWest
        };

        public override Piece Copy()
        {
            Queen copy = new Queen(this.Color);
            copy.HasMoved = this.HasMoved;
            return copy;
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
            => MovesInDirections(from, board, Directions)
                .Select(to => new NormalMove(from, to));
    }
}
