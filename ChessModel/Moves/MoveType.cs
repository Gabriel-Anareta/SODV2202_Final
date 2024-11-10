namespace ChessModel
{
    /// <summary>
    /// Represents the type of a move
    /// </summary>
    public enum MoveType
    {
        Normal,
        CastleKingSide,
        CastleQueenSide,
        DoublePawnPush,
        EnPassant,
        PawnPromotion
    }
}
