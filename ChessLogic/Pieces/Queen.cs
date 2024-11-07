using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel
{
    public class Queen(PlayerColor color) : Piece
    {
        public override PieceType Type => PieceType.Queen;
        public override PlayerColor Color { get; } = color;

        public override Piece Copy()
        {
            Queen copy = new Queen(this.Color);
            copy.HasMoved = this.HasMoved;
            return copy;
        }
    }
}
