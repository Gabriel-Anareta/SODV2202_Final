namespace ChessModel
{
    public class DoublePawnPush : Move
    {
        public override MoveType Type => MoveType.DoublePawnPush;
        public override Position From { get; }
        public override Position To { get; }

        public readonly Position EnPassantSquare;

        public DoublePawnPush(Position from, Position to, PlayerColor color)
        {
            From = from;
            To = to;
            EnPassantSquare = color switch
            {
                PlayerColor.White => new Position(From.File, (From.Rank + To.Rank) / 2),
                PlayerColor.Black => new Position(From.File, (From.Rank + To.Rank) / 2),
                PlayerColor.Red => new Position(From.File, (From.Rank + To.Rank) / 2),
                PlayerColor.Green => new Position((From.File + To.File) / 2, From.Rank),
                PlayerColor.Yellow => new Position(From.File, (From.Rank + To.Rank) / 2),
                _ => new Position((From.File + To.File) / 2, From.Rank)
            };
        }

        public override void Execute(Board board, bool raisingCaptures = false)
        {
            PlayerColor color = board[From].Color;
            board.SetEnPassantSquare(color, this);

            new NormalMove(From, To).Execute(board);
        }
    }
}
