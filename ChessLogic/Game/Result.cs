﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel.Game
{
    public class Result(PlayerColor winner, EndReason reason)
    {
        public PlayerColor Winner { get; set; } = winner;
        public EndReason Reason { get; set; } = reason;

        public static Result Win(PlayerColor winner)
            => new Result(winner, EndReason.Checkmate);

        public static Result Draw(EndReason reason)
            => new Result(PlayerColor.None, reason);
    }
}
