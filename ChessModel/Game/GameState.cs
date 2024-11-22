using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel
{
    public abstract class GameState
    {
        public Board GameBoard { get; set; }
        public PlayerColor CurrentPlayer { get; set; }
        public Result? EndResult { get; protected set; } = null;
        

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
        public IEnumerable<Move> ValidMovesFor(Position pos)
        {
            if (GameBoard.IsEmptyPosition(pos) || GameBoard[pos].Color != CurrentPlayer)
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
        public void ExecuteMove(Move move)
        {
            GameBoard.SetEnPassantSquare(CurrentPlayer, null);
            move.Execute(GameBoard);
            CurrentPlayer = PlayerManager.Next(CurrentPlayer);
            CheckGameOver();
        }

        /// <summary>
        /// Checks for a game over state
        /// </summary>
        protected abstract void CheckGameOver();
    }
}
