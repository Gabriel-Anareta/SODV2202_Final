﻿namespace ChessModel
{
    public class Result(PlayerColor winner, EndReason reason)
    {
        public PlayerColor Winner { get; set; } = winner;
        public EndReason Reason { get; set; } = reason;

        public static Result Win(PlayerColor winner, EndReason reason)
            => new Result(winner, reason);

        public static Result Draw(EndReason reason)
            => new Result(PlayerColor.None, reason);
    }
}
