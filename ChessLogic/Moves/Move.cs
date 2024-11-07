using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel.Moves
{
    /// <summary>
    /// Represents a move on a board
    /// </summary>
    public abstract class Move
    {
        public abstract MoveType Type { get; }
        public abstract Position From { get; }
        public abstract Position To { get; }

        /// <summary>
        /// Executes the current move on the given board
        /// </summary>
        /// <param name="board"></param>
        public abstract void Execute(Board board);
    }
}
