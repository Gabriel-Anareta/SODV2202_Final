﻿namespace ChessModel
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

        public override bool Execute(Board board, bool raisingCaptures = false)
        {
            Piece fromPiece = board[From];
            Piece toPiece = board[To];
            board[To] = fromPiece;
            board[From] = new EmptyPiece();
            fromPiece.HasMoved = true;

            if (toPiece.Type != PieceType.None && raisingCaptures)
                OnCapturedPiece(toPiece);

            return toPiece.Type != PieceType.None || fromPiece.Type == PieceType.Pawn;
        }

        public static NormalMove ToMove(string[] moveArgs)
        {
            Position from = Position.ToPosition(moveArgs[0]);
            Position to = Position.ToPosition(moveArgs[1]);
            return new NormalMove(from, to);
        }

        public override string ToString()
            => base.ToString();
    }
}
