
namespace ChessModel
{
    public class GameState4Player : GameState
    {
        public Dictionary<PlayerColor, int> PlayerScore { get; set; }
        
        public GameState4Player(Board4Player board, PlayerColor player)
        {
            PlayerScore = new Dictionary<PlayerColor, int>
            {
                { PlayerColor.Red, 0 },
                { PlayerColor.Green, 0 },
                { PlayerColor.Yellow, 0 },
                { PlayerColor.Blue, 0 },
            };
            
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
