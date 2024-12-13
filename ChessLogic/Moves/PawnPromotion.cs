using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override void Execute(Board board)
        {
            // Create promotion piece
            Piece promotionPiece = CreatePromotionPiece(board[From].Color);
            promotionPiece.HasMoved = true;

            // Update board positions
            board[From] = null;
            board[To] = promotionPiece;
        }

        private Piece CreatePromotionPiece(PlayerColor color)
        {
            return _promotedTo switch
            {
                PieceType.Knight => new Knight(color),
                PieceType.Bishop => new Bishop(color),
                PieceType.Rook => new Rook(color),
                PieceType.Queen => new Queen(color),
                _ => new Pawn(color)
            };
        }
    }
}
