namespace ChessModel
{
    public class EnPassant : Move
    {
        public override MoveType Type => MoveType.EnPassant;
        public override Position From { get; }
        public override Position To { get; }

        private readonly Position _capturedPos;

        public EnPassant(Position from, Position to, Position capturePos)
        {
            From = from;
            To = to;
            _capturedPos = capturePos;
        }

        public override bool Execute(Board board, bool raisingCaptures = false)
        {
            Piece capturedPiece = board[_capturedPos];

            if (raisingCaptures)
                OnCapturedPiece(capturedPiece);

            board[_capturedPos] = new EmptyPiece();
            return new NormalMove(From, To).Execute(board, raisingCaptures);
        }

        public static EnPassant ToEnPassant(string[] enPassantArgs)
        {
            Position from = Position.ToPosition(enPassantArgs[0]);
            Position to = Position.ToPosition(enPassantArgs[1]);
            Position captured = Position.ToPosition(enPassantArgs[3]);
            return new EnPassant(from, to, captured);
        }

        public override string ToString()
            => $"{From}-{To}-EP-{_capturedPos}";
    }
}
