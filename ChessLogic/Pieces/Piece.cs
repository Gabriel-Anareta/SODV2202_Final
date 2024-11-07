using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel
{
    /// <summary>
    /// Implements base piece functionality and properties
    /// </summary>
    public abstract class Piece
    {
        public abstract PieceType Type { get; }
        public abstract PlayerColor Color { get; }
        public bool HasMoved { get; set; } = false;

        /// <summary>
        /// Copies the given Piece
        /// </summary>
        /// <returns>A new instance of the respective piece type</returns>
        public abstract Piece Copy();
    }
}
