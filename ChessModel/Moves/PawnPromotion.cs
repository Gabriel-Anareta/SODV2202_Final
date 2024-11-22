namespace ChessModel
{
    /// <summary>
    /// Represents a move where a pawn is promoted
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="promotedTo"></param>
    public class PawnPromotion(Position from, Position to, PieceType promotedTo) : Move
    {
        public override MoveType Type => MoveType.PawnPromotion;
        public override Position From { get; } = from;
        public override Position To { get; } = to;

        private PieceType _promotedTo = promotedTo;

        public override void Execute(Board board, bool raisingCaptures = false)
        {
            // Create promotion piece
            Piece promotionPiece = CreatePromotionPiece(board[From].Color);
            promotionPiece.HasMoved = true;

            // Update board positions
            board[To] = promotionPiece;
            board[From] = new EmptyPiece();
        }

        private Piece CreatePromotionPiece(PlayerColor color)
        {
            return _promotedTo switch
            {
                PieceType.PromotedKnight => new Knight(color) { Type = PieceType.PromotedRook },
                PieceType.PromotedBishop => new Bishop(color) { Type = PieceType.PromotedBishop },
                PieceType.PromotedRook => new Rook(color) { Type = PieceType.PromotedRook },
                PieceType.PromotedQueen => new Queen(color) { Type = PieceType.PromotedQueen },
                _ => new Pawn(color)
            };
        }
    }
}
