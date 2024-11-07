using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel
{
    /// <summary>
    /// Handles the game logic of the chess game
    /// </summary>
    public class GameState(Board board, PlayerColor player)
    {
        public Board GameBoard { get; set; } = board;
        public PlayerColor CurrentPlayer { get; set; } = player;
    }
}
