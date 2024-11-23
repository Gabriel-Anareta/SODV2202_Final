
namespace ChessModel
{
    /// <summary>
    /// Represents a king - implements piece
    /// </summary>
    /// <param name="color"></param>
    public class King : Piece
    {
        private static readonly List<Direction> _allDirections = new List<Direction>
        {
            Direction.North,
            Direction.East,
            Direction.South,
            Direction.West,
            Direction.NorthEast,
            Direction.NorthWest,
            Direction.SouthEast,
            Direction.SouthWest
        };

        public King(PlayerColor color)
        {
            Type = PieceType.King;
            Color = color;
            Image = color.GetImage(Type);
        }

        public override Piece Copy()
        {
            King copy = new King(this.Color);
            copy.HasMoved = this.HasMoved;
            return copy;
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            foreach (Position pos in ValidMoves(from, board))
                yield return new NormalMove(from, pos);

            if (CanCaslte(from, board, MoveType.CastleKingSide))
                yield return new Castle(from, MoveType.CastleKingSide, Color);

            if (CanCaslte(from, board, MoveType.CastleQueenSide))
                yield return new Castle(from, MoveType.CastleQueenSide, Color);
        }

        public override bool CanCaptureOpponentKing(Position from, Board board, PlayerColor checkColor)
        {
            return ValidMoves(from, board)
                .Any(pos =>
                    board[pos] != null
                    && board[pos].Type == PieceType.King
                    && board[pos].Color == checkColor
                );
        }

        private IEnumerable<Position> ValidMoves(Position pos, Board board)
        {
            foreach (Direction dir in _allDirections)
            {
                Position to = pos + dir;

                if (!board.IsValidPosition(to))
                    continue;

                if (board.IsEmptyPosition(to) || board[to].Color != Color)
                    yield return to;
            }
        }

        private static bool IsUnmovedRook(Position rookPos, Board board)
        {
            if (board[rookPos] == null)
                return false;

            return !board[rookPos].HasMoved;
        }

        public bool CanCaslte(Position from, Board board, MoveType moveType)
        {
            if (HasMoved)
                return false;

            Position rookPos = moveType.RookPos(Color, from);
            List<Position> betweenPos = moveType.BetweenPos(Color, from);

            return
                IsUnmovedRook(rookPos, board)
                && betweenPos.All(pos => board.IsEmptyPosition(pos));
        }
    }
}
