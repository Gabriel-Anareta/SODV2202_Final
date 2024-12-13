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
        private readonly PlayerColor _color;

        public Castle(Position kingPos, MoveType castleType, PlayerColor color)
        {
            Type = castleType;
            From = kingPos;

            _kingMoveDir = castleType.CastleDir(color);
            To = castleType.KingTo(color, From);
            _rookFrom = castleType.RookPos(color, From);
            _rookTo = castleType.RookTo(color, From);
        }

        public override bool Execute(Board board, bool raisingCaptures = false)
        {
            new NormalMove(From, To).Execute(board);
            new NormalMove(_rookFrom, _rookTo).Execute(board);

            return false;
        }

        public override bool IsValidMove(Board board)
        {
            PlayerColor color = board[From].Color;

            if (board.IsInCheck(color))
                return false;

            Board copy = board.Copy();
            Position KingPosInCopy = From;
            List<Position> between = Type.BetweenPos(color, From);

            for (int i = 0; i < between.Count; i++)
            {
                new NormalMove(KingPosInCopy, between[i]).Execute(copy);
                KingPosInCopy += _kingMoveDir;

                if (copy.IsInCheck(color))
                    return false;
            }

            return true;
        }

        public static Castle ToCastle(string[] castleArgs)
        {
            Position from = Position.ToPosition(castleArgs[0]);
            MoveType type = castleArgs[2].StringAsCastleType();
            PlayerColor color = (PlayerColor)Enum.Parse(typeof(PlayerColor), castleArgs[3]);
            return new Castle(from, type, color);
        }

        public override string ToString()
        {
            string castleType = Type.CastleTypeAsString();
            string color = _color.ToString();

            return $"{From}-{To}-{castleType}-{color}";
        }
    }
}
