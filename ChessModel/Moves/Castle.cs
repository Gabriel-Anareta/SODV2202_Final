namespace ChessModel
{
    public class Castle : Move
    {
        public override MoveType Type { get; }
        public override Position From { get; }
        public override Position To { get; }

        private readonly Direction _kingMoveDir;
        private readonly Position _rookFrom;
        private readonly Position _rookTo;

        public Castle(Position kingPos, MoveType castleType, PlayerColor color)
        {
            Type = castleType;
            From = kingPos;

            _kingMoveDir = castleType.CastleDir(color);
            To = castleType.KingTo(color, From);
            _rookFrom = castleType.RookPos(color, From);
            _rookTo = castleType.RookTo(color, From);
        }

        public override void Execute(Board board)
        {
            new NormalMove(From, To).Execute(board);
            new NormalMove(_rookFrom, _rookTo).Execute(board);
        }

        public override bool IsValidMove(Board board)
        {
            PlayerColor color = board[From].Color;

            if (board.IsInCheck(color))
                return false;

            Board copy = board.Copy();
            Position KingPosInCopy = From;

            for (int i = 0; i < 2; i++)
            {
                new NormalMove(KingPosInCopy, KingPosInCopy + _kingMoveDir).Execute(copy);
                KingPosInCopy += _kingMoveDir;

                if (copy.IsInCheck(color))
                    return false;
            }

            return true;
        }
    }
}
