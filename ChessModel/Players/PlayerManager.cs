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

        /// <summary>
        /// Gets all opponents of this player
        /// </summary>
        /// <param name="color"></param>
        /// <returns>A List of PlayerColors containing all opponents of this player</returns>
        public static List<PlayerColor> Opponents(this PlayerColor color)
        {
            return color switch
            {
                PlayerColor.White => new List<PlayerColor>
                {
                    PlayerColor.Black
                },   
                PlayerColor.Black => new List<PlayerColor>
                {
                    PlayerColor.White
                },   
                PlayerColor.Red => new List<PlayerColor>
                {
                    PlayerColor.Yellow,
                    PlayerColor.Green,
                    PlayerColor.Blue
                },  
                PlayerColor.Green => new List<PlayerColor>
                {
                    PlayerColor.Yellow,
                    PlayerColor.Blue,
                    PlayerColor.Red
                },
                PlayerColor.Yellow => new List<PlayerColor>
                {
                    PlayerColor.Blue,
                    PlayerColor.Red,
                    PlayerColor.Green
                },
                PlayerColor.Blue => new List<PlayerColor>
                {
                    PlayerColor.Red,
                    PlayerColor.Green,
                    PlayerColor.Yellow
                }, 
                _ => new List<PlayerColor>
                {
                    PlayerColor.None
                }
            };
        }
    }
}
