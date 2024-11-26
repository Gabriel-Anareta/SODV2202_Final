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
            Piece fromPiece = board[From];
            Piece capturedPiece = board[_capturedPos];

            if (raisingCaptures)
                OnCapturedPiece(fromPiece, capturedPiece);

            board[_capturedPos] = new EmptyPiece();
            return new NormalMove(From, To).Execute(board, raisingCaptures);
        }
    }
}
