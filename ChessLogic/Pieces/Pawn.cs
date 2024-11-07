using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel
{
    public class Pawn(PlayerColor color) : Piece
    {
        public override PieceType Type => PieceType.Pawn;
        public override PlayerColor Color { get; } = color;

        public override Piece Copy()
        {
            Pawn copy = new Pawn(this.Color);
            copy.HasMoved = this.HasMoved;
            return copy;
        }
    }
}
