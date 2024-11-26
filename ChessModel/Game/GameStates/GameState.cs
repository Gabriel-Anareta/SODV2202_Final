namespace ChessModel
{
    public abstract class GameState
    {
        public event Action<Result> GameEnded;
        
        public Board GameBoard { get; set; }
        public PlayerColor CurrentPlayer { get; set; }
        public Result? EndResult { get; protected set; } = null;
        public int ColorsInPlay { get; set; }

        protected int _reversableMoves = 0;
        

        /// <summary>
        /// Checks the current state of the game
        /// </summary>
        /// <returns>True if EndResult is null</returns>
        public bool IsGameOver()
           => EndResult != null;

        /// <summary>
        /// Gets all the valid moves for a given position
        /// </summary>
        /// <param name="pos"></param>
        /// <returns>An IEnumerable holding all positions that can be reached from the current location of a piece</returns>
        public IEnumerable<Move> ValidMovesFor(Position pos, PlayerColor color = PlayerColor.None)
        {
            if (color == PlayerColor.None)
                color = CurrentPlayer;
            
            if (GameBoard.IsEmptyPosition(pos) || GameBoard[pos].Color != color)
                return Enumerable.Empty<Move>();

            Piece piece = GameBoard[pos];
            return piece.GetMoves(pos, GameBoard)
                .Where(move => move.IsValidMove(GameBoard));
        }

        /// <summary>
        /// Gets all the valid moves for a given player
        /// </summary>
        /// <param name="player"></param>
        /// <returns>An IEnumerable holding all positions that can be reached by the given player</returns>
        public IEnumerable<Move> ValidMovesFor(PlayerColor player)
            => GameBoard.PiecePositionsFor(player)
                .SelectMany(pos => GameBoard[pos].GetMoves(pos, GameBoard))
                .Where(move => move.IsValidMove(GameBoard));

        /// <summary>
        /// Executes the given move and updates the game state
        /// </summary>
        /// <param name="move"></param>
        public abstract void ExecuteMove(Move move);

        /// <summary>
        /// Checks for a game over state
        /// </summary>
        protected abstract void CheckGameOver();

        /// <summary>
        /// Checks for the Fifty Move Rule state
        /// </summary>
        /// <returns>True if the count of reversable moves made by both players is 50</returns>
        protected bool FiftyMoveRule(int colorsInPlay)
            => _reversableMoves == 50 * colorsInPlay;
    }
}
