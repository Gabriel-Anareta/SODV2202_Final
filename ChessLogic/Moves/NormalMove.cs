using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel
{
    /// <summary>
    /// Represents a normal move - moving only one piece to another square
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    public class NormalMove(Position from, Position to) : Move
    {
        public override MoveType Type => MoveType.Normal;
        public override Position From { get; } = from;
        public override Position To { get; } = to;

        public override void Execute(Board board)
        {
            Piece piece = board[From];
            board[To] = piece;
            board[From] = null;
            piece.HasMoved = true;
        }
    }
}
