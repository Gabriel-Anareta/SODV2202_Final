namespace ChessModel
{
    public class EnPassant : Move
    {
        public override MoveType Type => MoveType.EnPassant;
        public override Position From { get; }
        public override Position To { get; }

        private readonly Position _capturedPos;

        public EnPassant(Position from, Position to)
        {
            From = from;
            To = to;
            _capturedPos = new Position(To.File, From.Rank);
        }

        public override void Execute(Board board)
        {
            new NormalMove(From, To).Execute(board);
            board[_capturedPos] = new EmptyPiece();
        }
    }
}
