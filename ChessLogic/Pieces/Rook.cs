namespace ChessModel
{
    /// <summary>
    /// Represents a rook - implements piece
    /// </summary>
    /// <param name="color"></param>
    public class Rook(PlayerColor color) : Piece
    {
        public override PieceType Type => PieceType.Rook;
        public override PlayerColor Color { get; } = color;

        private static readonly List<Direction> Directions = new List<Direction>
        {
            Direction.North,
            Direction.South,
            Direction.East,
            Direction.West
        };

        public override Piece Copy()
        {
            Rook copy = new Rook(this.Color);
            copy.HasMoved = this.HasMoved;
            return copy;
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
           => MovesInDirections(from, board, Directions)
               .Select(to => new NormalMove(from, to));
    }
}
