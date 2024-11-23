namespace ChessModel
{
    /// <summary>
    /// Handles the game logic of the chess game
    /// </summary>
    public class GameState2Player : GameState
    {
        public GameState2Player(Board2Player board, PlayerColor player)
        {
            GameBoard = board;
            CurrentPlayer = player;
        }

        public override void ExecuteMove(Move move)
        {
            // Execute move
            GameBoard.SetEnPassantSquare(CurrentPlayer, null);
            move.Execute(GameBoard, true);

            // Update game state
            CurrentPlayer = PlayerManager.Next(CurrentPlayer);
            CheckGameOver();
        }

        protected override void CheckGameOver()
        {
            if (!ValidMovesFor(CurrentPlayer).Any())
            {
                if (GameBoard.IsInCheck(CurrentPlayer))
                    EndResult = Result.Win(CurrentPlayer.Next(), EndReason.Checkmate);
                else
                    EndResult = Result.Draw(EndReason.Stalemate);
            }
            
            if (GameBoard.InsufficientMaterial())
                EndResult = Result.Draw(EndReason.InsufficientMaterial);
        }
    }
}
