
namespace ChessModel
{
    public class GameState4Player : GameState
    {
        public GameState4Player(Board4Player board, PlayerColor player)
        {
            GameBoard = board;
            CurrentPlayer = player;
            Move.CapturedPieceEvent += OnCapturedPiece;
        }

        protected override void CheckGameOver()
        {
            
        }

        private void OnCapturedPiece(PlayerColor movingPlayer, PlayerColor capturedPlayer, PieceType capturedPiece)
        {

        }
    }
}
