namespace ChessModel
{
    /// <summary>
    /// Represents a move on a board
    /// </summary>
    public abstract class Move
    {
        public abstract MoveType Type { get; }
        public abstract Position From { get; }
        public abstract Position To { get; }

        public delegate void Capture(PlayerColor movingPlayer, PlayerColor capturedPlayer, PieceType capturedPiece);
        public static event Capture CapturedPieceEvent;

        /// <summary>
        /// Executes the current move on the given board
        /// </summary>
        /// <param name="board"></param>
        public abstract void Execute(Board board, bool raiseCaptures = false);

        /// <summary>
        /// Checks the validity of a current move on check positions
        /// </summary>
        /// <param name="board"></param>
        /// <returns>True if the position does not bring the king into check or if the move takes the king out of check</returns>
        public virtual bool IsValidMove(Board board)
        {
            PlayerColor color = board[From].Color;
            Board copy = board.Copy();
            Execute(copy);
            return !copy.IsInCheck(color);
        }

        protected void OnCapturedPiece(PlayerColor movingPlayer, PlayerColor capturedPlayer, PieceType capturedPiece)
            => CapturedPieceEvent?.Invoke(movingPlayer, capturedPlayer, capturedPiece);
    }
}
