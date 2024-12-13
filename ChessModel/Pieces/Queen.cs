namespace ChessModel
{
    /// <summary>
    /// Represents a queen - implements piece
    /// </summary>
    /// <param name="color"></param>
    public class Queen : Piece
    {
        private static readonly List<Direction> Directions = new List<Direction>
        {
            Direction.North,
            Direction.South,
            Direction.East,
            Direction.West,
            Direction.NorthEast,
            Direction.NorthWest,
            Direction.SouthEast,
            Direction.SouthWest
        };

        public Queen(PlayerColor color)
        {
            Type = PieceType.Queen;
            Color = color;
            Image = color.GetImage(Type);
        }

        public override Piece Copy()
        {
            Queen copy = new Queen(this.Color);
            copy.HasMoved = this.HasMoved;
            return copy;
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
            => MovesInDirections(from, board, Directions)
                .Select(to => new NormalMove(from, to));
    }
}
