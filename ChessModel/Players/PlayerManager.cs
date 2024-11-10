namespace ChessModel
{
    public static class PlayerManager
    {
        /// <summary>
        /// Gets the next player in order
        /// </summary>
        /// <param name="color"></param>
        /// <returns>A PlayerColor that is next in the order</returns>
        public static PlayerColor Next(this PlayerColor color)
        {
            return color switch
            {
                PlayerColor.White => PlayerColor.Black,
                PlayerColor.Black => PlayerColor.White,
                PlayerColor.Red => PlayerColor.Green,
                PlayerColor.Green => PlayerColor.Yellow,
                PlayerColor.Yellow => PlayerColor.Blue,
                PlayerColor.Blue => PlayerColor.Red,
                _ => PlayerColor.None
            };
        }

        /// <summary>
        /// Gets the player opposite of this player
        /// </summary>
        /// <param name="color"></param>
        /// <returns>A PlayerColor that is opposite of the given player</returns>
        public static PlayerColor Opposite(this PlayerColor color)
        {
            return color switch
            {
                PlayerColor.White => PlayerColor.Black,
                PlayerColor.Black => PlayerColor.White,
                PlayerColor.Red => PlayerColor.Yellow,
                PlayerColor.Green => PlayerColor.Blue,
                PlayerColor.Yellow => PlayerColor.Red,
                PlayerColor.Blue => PlayerColor.Green,
                _ => PlayerColor.None
            };
        }
    }
}
