using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel
{
    public class DoublePawnPush : Move
    {
        public override MoveType Type => MoveType.DoublePawnPush;
        public override Position From { get; }
        public override Position To { get; }

        private readonly Position _enPassantSquare;

        public DoublePawnPush(Position from, Position to, PlayerColor color)
        {
            From = from;
            To = to;
            _enPassantSquare = color switch
            {
                PlayerColor.White => new Position(From.File, (From.Rank + To.Rank) / 2),
                PlayerColor.Black => new Position(From.File, (From.Rank + To.Rank) / 2),
                PlayerColor.Red => new Position(From.File, (From.Rank + To.Rank) / 2),
                PlayerColor.Green => new Position((From.File + To.File) / 2, From.Rank),
                PlayerColor.Yellow => new Position(From.File, (From.Rank + To.Rank) / 2),
                _ => new Position((From.File + To.File) / 2, From.Rank)
            };
        }

        public override void Execute(Board board)
        {
            PlayerColor color = board[From].Color;
            board.SetEnPassantSquare(color, _enPassantSquare);

            new NormalMove(From, To).Execute(board);
        }
    }
}
