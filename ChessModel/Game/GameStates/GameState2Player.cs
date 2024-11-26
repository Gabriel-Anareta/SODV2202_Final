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
            ColorsInPlay = 2;
        }

        public override void ExecuteMove(Move move)
        {
            // Execute move
            GameBoard.SetEnPassantSquare(CurrentPlayer, null);
            bool pawnMovedOrCapture = move.Execute(GameBoard, true);

            if (pawnMovedOrCapture)
                _reversableMoves = 0;
            else
                _reversableMoves++;

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
            else if (GameBoard.InsufficientMaterial())
            {
                EndResult = Result.Draw(EndReason.InsufficientMaterial);
            }
            else if (FiftyMoveRule(ColorsInPlay))
            {
                EndResult = Result.Draw(EndReason.FiftyMoveRule);
            }
        }
    }
}
