using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel
{
    /// <summary>
    /// Represents a bishop - implements piece
    /// </summary>
    /// <param name="color"></param>
    public class Bishop(PlayerColor color) : Piece
    {
        public override PieceType Type => PieceType.Bishop;
        public override PlayerColor Color { get; } = color;

        private static readonly List<Direction> Directions = new List<Direction>
        {
            Direction.NorthEast,
            Direction.NorthWest,
            Direction.SouthEast,
            Direction.SouthWest
        };

        public override Piece Copy()
        {
            Bishop copy = new Bishop(this.Color);
            copy.HasMoved = this.HasMoved;
            return copy;
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
            => MovesInDirections(from, board, Directions)
                .Select(to => new NormalMove(from, to));
    }
}
