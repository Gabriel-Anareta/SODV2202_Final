using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel.Moves
{
    /// <summary>
    /// Represents the type of a move
    /// </summary>
    public enum MoveType
    {
        Normal,
        CastleKingSide,
        CastleQueenSide,
        DoublePawnPush,
        EnPassant,
        PawnPromotion
    }
}
