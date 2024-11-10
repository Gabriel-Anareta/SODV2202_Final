namespace ChessModel
{
    public static class PlayerManager
    {
        // Images from https://commons.wikimedia.org/wiki/Category:SVG_chess_pieces
        private static readonly Dictionary<PieceType, Image> _blackImages = new Dictionary<PieceType, Image>
        {
            { PieceType.King, Properties.Resources.King_Black },
            { PieceType.Queen, Properties.Resources.Queen_Black },
            { PieceType.Rook, Properties.Resources.Rook_Black },
            { PieceType.Knight, Properties.Resources.Knight_Black },
            { PieceType.Bishop, Properties.Resources.Bishop_Black },
            { PieceType.Pawn, Properties.Resources.Pawn_Black }
        };
        private static readonly Dictionary<PieceType, Image> _whiteImages = new Dictionary<PieceType, Image>
        {
            { PieceType.King, Properties.Resources.King_White },
            { PieceType.Queen, Properties.Resources.Queen_White },
            { PieceType.Rook, Properties.Resources.Rook_White },
            { PieceType.Knight, Properties.Resources.Knight_White },
            { PieceType.Bishop, Properties.Resources.Bishop_White },
            { PieceType.Pawn, Properties.Resources.Pawn_White }
        };
        private static readonly Dictionary<PieceType, Image> _redImages = new Dictionary<PieceType, Image>
        {
            { PieceType.King, null },
            { PieceType.Queen, null },
            { PieceType.Rook, null },
            { PieceType.Knight, null },
            { PieceType.Bishop, null },
            { PieceType.Pawn, null }
        };
        private static readonly Dictionary<PieceType, Image> _greenImages = new Dictionary<PieceType, Image>
        {
            { PieceType.King, null },
            { PieceType.Queen, null },
            { PieceType.Rook, null },
            { PieceType.Knight, null },
            { PieceType.Bishop, null },
            { PieceType.Pawn, null }
        };
        private static readonly Dictionary<PieceType, Image> _yellowImages = new Dictionary<PieceType, Image>
        {
            { PieceType.King, null },
            { PieceType.Queen, null },
            { PieceType.Rook, null },
            { PieceType.Knight, null },
            { PieceType.Bishop, null },
            { PieceType.Pawn, null }
        };
        private static readonly Dictionary<PieceType, Image> _blueImages = new Dictionary<PieceType, Image>
        {
            { PieceType.King, null },
            { PieceType.Queen, null },
            { PieceType.Rook, null },
            { PieceType.Knight, null },
            { PieceType.Bishop, null },
            { PieceType.Pawn, null }
        };

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

        public static Image GetImage(this PlayerColor color, PieceType type)
        {
            return color switch
            {
                PlayerColor.White => _whiteImages[type],
                PlayerColor.Black => _blackImages[type],
                PlayerColor.Red => _redImages[type],
                PlayerColor.Green => _greenImages[type],
                PlayerColor.Yellow => _yellowImages[type],
                _ => _blueImages[type]
            };
        }

        public static Image GetImage(this PieceType piece, PlayerColor color)
        {
            return color.GetImage(piece);
        }
    }
}
