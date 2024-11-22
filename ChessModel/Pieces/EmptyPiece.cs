using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel
{
    public class EmptyPiece : Piece
    {
        public override PieceType Type { get; set; }
        public override PlayerColor Color { get; }
        public override Image Image { get; }

        public EmptyPiece()
        {
            Type = PieceType.None;
            Color = PlayerColor.None;
            Image = Color.GetImage(Type);
        }

        public override Piece Copy() => new EmptyPiece();
        public override IEnumerable<Move> GetMoves(Position from, Board board) => Enumerable.Empty<Move>();
    }
}
