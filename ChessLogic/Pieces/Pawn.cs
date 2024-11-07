namespace ChessModel
{
    /// <summary>
    /// Represents a pawn - implements piece
    /// </summary>
    /// <param name="color"></param>
    public class Pawn(PlayerColor color) : Piece
    {
        public override PieceType Type => PieceType.Pawn;
        public override PlayerColor Color { get; } = color;

        private readonly Direction _relativeForward = color switch
        {
            PlayerColor.White => Direction.North,
            PlayerColor.Black => Direction.South,
            PlayerColor.Red => Direction.North,
            PlayerColor.Green => Direction.West,
            PlayerColor.Yellow => Direction.South,
            PlayerColor.Blue => Direction.East,
            _ => new Direction(0, 0)
        };
        private readonly Direction _relativeLeft = color switch
        {
            PlayerColor.White => Direction.West,
            PlayerColor.Black => Direction.East,
            PlayerColor.Red => Direction.West,
            PlayerColor.Green => Direction.South,
            PlayerColor.Yellow => Direction.East,
            PlayerColor.Blue => Direction.North,
            _ => new Direction(0, 0)
        };
        private readonly Direction _relativeRight = color switch
        {
            PlayerColor.White => Direction.East,
            PlayerColor.Black => Direction.West,
            PlayerColor.Red => Direction.East,
            PlayerColor.Green => Direction.North,
            PlayerColor.Yellow => Direction.West,
            PlayerColor.Blue => Direction.South,
            _ => new Direction(0, 0)
        };

        public override Piece Copy()
        {
            Pawn copy = new Pawn(this.Color);
            copy.HasMoved = this.HasMoved;
            return copy;
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
            => ForwardMoves(from, board)
                .Concat(DiagonalMoves(from, board))
                .Select(to => new NormalMove(from, to));

        public override bool CanCaptureOpponentKing(Position from, Board board)
        {
            return DiagonalMoves(from, board)
                .Any(pos =>
                    board[pos] != null
                    && board[pos].Type == PieceType.King
                );
        }

        private IEnumerable<Position> ForwardMoves(Position from, Board board)
        {
            Position forward1 = from + _relativeForward;

            if (CanMoveTo(forward1, board))
            {
                yield return forward1;

                Position forward2 = forward1 + _relativeForward;

                if (!HasMoved && CanMoveTo(forward2, board))
                    yield return forward2;
            }
        }

        private IEnumerable<Position> DiagonalMoves(Position from, Board board)
        {
            foreach (Direction dir in new List<Direction> { _relativeLeft, _relativeRight })
            {
                Position to = from + dir + _relativeForward;

                if (CanCaptureAt(to, board))
                    yield return to;
            }
        }

        private bool CanMoveTo(Position pos, Board board)
        {
            return board.IsValidPosition(pos) && board.IsEmptyPosition(pos);
        }

        private bool CanCaptureAt(Position pos, Board board)
        {
            if (!board.IsValidPosition(pos) || board.IsEmptyPosition(pos))
                return false;

            return board[pos].Color != Color;
        }
    }
}
