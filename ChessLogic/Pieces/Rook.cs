using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel
{
    /// <summary>
    /// Represents a rook - implements piece
    /// </summary>
    /// <param name="color"></param>
    public class Rook(PlayerColor color) : Piece
    {
        public override PieceType Type => PieceType.Rook;
        public override PlayerColor Color { get; } = color;

        public override Piece Copy()
        {
            Rook copy = new Rook(this.Color);
            copy.HasMoved = this.HasMoved;
            return copy;
        }
    }
}
