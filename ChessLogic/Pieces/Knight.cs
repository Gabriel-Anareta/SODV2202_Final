using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel
{
    public class Knight(PlayerColor color) : Piece
    {
        public override PieceType Type => PieceType.Knight;
        public override PlayerColor Color { get; } = color;

        public override Piece Copy()
        {
            Knight copy = new Knight(this.Color);
            copy.HasMoved = this.HasMoved;
            return copy;
        }
    }
}
