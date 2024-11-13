namespace ChessModel
{
    public class GameState4Player : GameState
    {
        public GameState4Player(Board4Player board, PlayerColor player)
        {
            GameBoard = board;
            CurrentPlayer = player;
        }

        protected override void CheckGameOver()
        {
            
        }
    }
}
