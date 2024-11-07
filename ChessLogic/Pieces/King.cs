using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel
{
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
    }
}
