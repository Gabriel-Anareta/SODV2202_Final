
namespace ChessModel
{
    /// <summary>
    /// Represents a pawn - implements piece
    /// </summary>
    /// <param name="color"></param>
    public class Pawn : Piece
    {
        public override PieceType Type { get; }
        public override PlayerColor Color { get; }
        public override Image Image { get; }

        private readonly Direction _relativeForward;
        private readonly Direction _relativeRight;
        private readonly Direction _relativeLeft;

        public Pawn(PlayerColor color)
        {
            Type = PieceType.Pawn;
            Color = color;
            Image = color.GetImage(Type);

            _relativeForward = color switch
            {
                PlayerColor.White => Direction.North,
                PlayerColor.Black => Direction.South,
                PlayerColor.Red => Direction.North,
                PlayerColor.Green => Direction.West,
                PlayerColor.Yellow => Direction.South,
                PlayerColor.Blue => Direction.East,
                _ => new Direction(0, 0)
            };
            _relativeRight = Direction.RelRight(_relativeForward);
            _relativeLeft = -1 * _relativeRight;
        }

        public override Piece Copy()
        {
            Pawn copy = new Pawn(this.Color);
            copy.HasMoved = this.HasMoved;
            return copy;
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
            => ForwardMoves(from, board)
                .Concat(DiagonalMoves(from, board));

        public override bool CanCaptureOpponentKing(Position from, Board board, PlayerColor checkColor)
            => DiagonalMoves(from, board)
                .Any(move =>
                    board[move.To] != null
                    && board[move.To].Type == PieceType.King
                    && board[move.To].Color == checkColor
                );

        private IEnumerable<Move> ForwardMoves(Position from, Board board)
        {
            Position forward1 = from + _relativeForward;

            if (!CanMoveTo(forward1, board))
                yield break;

            if (CanPromoteAt(forward1))
                foreach (Move promtionMove in PromotionMoves(from, forward1))
                    yield return promtionMove;
            else
                yield return new NormalMove(from, forward1);

            Position forward2 = forward1 + _relativeForward;

            if (!HasMoved && CanMoveTo(forward2, board))
                yield return new DoublePawnPush(from, forward2, Color);
        }

        private IEnumerable<Move> DiagonalMoves(Position from, Board board)
        {
            foreach (Direction dir in new List<Direction> { _relativeLeft, _relativeRight })
            {
                Position to = from + dir + _relativeForward;

                foreach (PlayerColor color in Color.Opponents())
                {
                    DoublePawnPush doublePawn = ((DoublePawnPush)board.GetEnPassantMove(color));
                    if (doublePawn == null)
                        continue;

                    if (to == doublePawn.EnPassantSquare)
                        yield return new EnPassant(from, to, doublePawn.To);
                }
                    
                if (!CanCaptureAt(to, board))
                    continue;

                if (CanPromoteAt(to))
                    foreach (Move promtionMove in PromotionMoves(from, to))
                        yield return promtionMove;
                else
                    yield return new NormalMove(from, to);
            }
        }

        private IEnumerable<Move> PromotionMoves(Position from, Position to)
        {
            yield return new PawnPromotion(from, to, PieceType.Knight);
            yield return new PawnPromotion(from, to, PieceType.Bishop);
            yield return new PawnPromotion(from, to, PieceType.Rook);
            yield return new PawnPromotion(from, to, PieceType.Queen);
            yield return new PawnPromotion(from, to, PieceType.Pawn);
        }

        private bool CanPromoteAt(Position pos)
        {
            return Color switch
            {
                PlayerColor.White => pos.Rank == 7,
                PlayerColor.Black => pos.Rank == 0,
                PlayerColor.Red => pos.Rank == 7,
                PlayerColor.Green => pos.File == 6,
                PlayerColor.Yellow => pos.Rank == 6,
                PlayerColor.Blue => pos.File == 7,
                _ => false
            };
        }

        private bool CanMoveTo(Position pos, Board board)
            => board.IsValidPosition(pos) && board.IsEmptyPosition(pos);

        private bool CanCaptureAt(Position pos, Board board)
        {
            if (!board.IsValidPosition(pos) || board.IsEmptyPosition(pos))
                return false;

            return board[pos].Color != Color;
        }
    }
}
