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

        public override void Execute(Board board, bool raisingCaptures = false)
        {
            Piece pieceFrom = board[From];
            Piece pieceTo = board[To];
            board[To] = pieceFrom;
            board[From] = new EmptyPiece();
            pieceFrom.HasMoved = true;

            if (pieceTo.Type != PieceType.None && raisingCaptures)
                OnCapturedPiece(pieceFrom.Color, pieceTo.Color, pieceTo.Type);
        }
    }
}
