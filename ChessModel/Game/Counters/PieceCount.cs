namespace ChessModel
{
    public abstract class PieceCount
    {
        public int TotalPieces { get; protected set; }

        public abstract void IncrementPieceCount(PlayerColor color, PieceType type);

        public abstract bool Any(PieceType type, Func<int, bool> condition);
    }
}
