namespace ChessModel
{
    public class DoublePawnPush : Move
    {
        public override MoveType Type => MoveType.DoublePawnPush;
        public override Position From { get; }
        public override Position To { get; }

        public readonly Position EnPassantSquare;

        private readonly PlayerColor _color;

        public DoublePawnPush(Position from, Position to, PlayerColor color)
        {
            From = from;
            To = to;
            _color = color;
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

        public override bool Execute(Board board, bool raisingCaptures = false)
        {
            PlayerColor color = board[From].Color;
            board.SetEnPassantSquare(color, this);

            return new NormalMove(From, To).Execute(board);
        }

        public static DoublePawnPush ToDoublePush(string[] pushArgs)
        {
            Position from = Position.ToPosition(pushArgs[0]);
            Position to = Position.ToPosition(pushArgs[1]);
            PlayerColor color = (PlayerColor)Enum.Parse(typeof(PlayerColor), pushArgs[3]);
            return new DoublePawnPush(from, to, color);
        }

        public override string ToString()
            => $"{From}-{To}-DP-{_color}";
    }
}
