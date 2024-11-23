
namespace ChessModel
{
    /// <summary>
    /// Represents a rook - implements piece
    /// </summary>
    /// <param name="color"></param>
    public class Rook : Piece
    {
        private static readonly List<Direction> Directions = new List<Direction>
        {
            Direction.North,
            Direction.South,
            Direction.East,
            Direction.West
        };

        public Rook(PlayerColor color)
        {
            Type = PieceType.Rook;
            Color = color;
            Image = color.GetImage(Type);
        }

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
