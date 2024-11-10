namespace ChessModel
{
    /// <summary>
    /// Represents a knight - implements piece
    /// </summary>
    /// <param name="color"></param>
    public class Knight : Piece
    {
        public override PieceType Type { get; }
        public override PlayerColor Color { get; }
        public override Image Image { get; }

        public Knight(PlayerColor color)
        {
            Type = PieceType.Knight;
            Color = color;
            Image = color.GetImage(Type);
        }

        public override Piece Copy()
        {
            Knight copy = new Knight(this.Color);
            copy.HasMoved = this.HasMoved;
            return copy;
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
            => ValidJumps(from, board)
                .Select(pos => new NormalMove(from, pos));

        private IEnumerable<Position> ValidJumps(Position from, Board board)
            => TheoreticalJumps(from)
                .Where(pos =>
                    board.IsValidPosition(pos)
                    && (board.IsEmptyPosition(pos) || board[pos].Color != this.Color)
                );

        private IEnumerable<Position> TheoreticalJumps(Position from)
        {
            foreach (Direction vDir in new List<Direction> { Direction.North, Direction.South })
            {
                foreach (Direction hDir in new List<Direction> { Direction.West, Direction.East })
                {
                    yield return from + 2 * vDir + hDir;
                    yield return from + 2 * hDir + vDir;
                }
            }
        }
    }
}
