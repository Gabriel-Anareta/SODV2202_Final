namespace ChessModel
{
    public static class PieceManager
    {
        // Images from https://commons.wikimedia.org/wiki/Category:SVG_chess_pieces
        private static readonly Dictionary<PieceType, Image> _blackImages = new Dictionary<PieceType, Image>
        {
            { PieceType.King, Properties.Resources.King_Black },
            { PieceType.Queen, Properties.Resources.Queen_Black },
            { PieceType.Rook, Properties.Resources.Rook_Black },
            { PieceType.Knight, Properties.Resources.Knight_Black },
            { PieceType.Bishop, Properties.Resources.Bishop_Black },
            { PieceType.Pawn, Properties.Resources.Pawn_Black },
            { PieceType.PromotedQueen, Properties.Resources.Queen_Black },
            { PieceType.PromotedRook, Properties.Resources.Rook_Black },
            { PieceType.PromotedKnight, Properties.Resources.Knight_Black },
            { PieceType.PromotedBishop, Properties.Resources.Bishop_Black },
        };
        private static readonly Dictionary<PieceType, Image> _whiteImages = new Dictionary<PieceType, Image>
        {
            { PieceType.King, Properties.Resources.King_White },
            { PieceType.Queen, Properties.Resources.Queen_White },
            { PieceType.Rook, Properties.Resources.Rook_White },
            { PieceType.Knight, Properties.Resources.Knight_White },
            { PieceType.Bishop, Properties.Resources.Bishop_White },
            { PieceType.Pawn, Properties.Resources.Pawn_White },
            { PieceType.PromotedQueen, Properties.Resources.Queen_White },
            { PieceType.PromotedRook, Properties.Resources.Rook_White },
            { PieceType.PromotedKnight, Properties.Resources.Knight_White },
            { PieceType.PromotedBishop, Properties.Resources.Bishop_White },
        };
        private static readonly Dictionary<PieceType, Image> _redImages = new Dictionary<PieceType, Image>
        {
            { PieceType.King, Properties.Resources.King_Red.byteArrayToImage() },
            { PieceType.Queen, Properties.Resources.Queen_Red.byteArrayToImage() },
            { PieceType.Rook, Properties.Resources.Rook_Red.byteArrayToImage() },
            { PieceType.Knight, Properties.Resources.Knight_Red.byteArrayToImage() },
            { PieceType.Bishop, Properties.Resources.Bishop_Red.byteArrayToImage() },
            { PieceType.Pawn, Properties.Resources.Pawn_Red.byteArrayToImage() },
            { PieceType.PromotedQueen, Properties.Resources.Queen_Red.byteArrayToImage() },
            { PieceType.PromotedRook, Properties.Resources.Rook_Red.byteArrayToImage() },
            { PieceType.PromotedKnight, Properties.Resources.Knight_Red.byteArrayToImage() },
            { PieceType.PromotedBishop, Properties.Resources.Bishop_Red.byteArrayToImage() },
        };
        private static readonly Dictionary<PieceType, Image> _greenImages = new Dictionary<PieceType, Image>
        {
            { PieceType.King, Properties.Resources.King_Green.byteArrayToImage() },
            { PieceType.Queen, Properties.Resources.Queen_Green.byteArrayToImage() },
            { PieceType.Rook, Properties.Resources.Rook_Green.byteArrayToImage() },
            { PieceType.Knight, Properties.Resources.Knight_Green.byteArrayToImage() },
            { PieceType.Bishop, Properties.Resources.Bishop_Green.byteArrayToImage() },
            { PieceType.Pawn, Properties.Resources.Pawn_Green.byteArrayToImage() },
            { PieceType.PromotedQueen, Properties.Resources.Queen_Green.byteArrayToImage() },
            { PieceType.PromotedRook, Properties.Resources.Rook_Green.byteArrayToImage() },
            { PieceType.PromotedKnight, Properties.Resources.Knight_Green.byteArrayToImage() },
            { PieceType.PromotedBishop, Properties.Resources.Bishop_Green.byteArrayToImage() },
        };
        private static readonly Dictionary<PieceType, Image> _yellowImages = new Dictionary<PieceType, Image>
        {
            { PieceType.King, Properties.Resources.King_Yellow.byteArrayToImage() },
            { PieceType.Queen, Properties.Resources.Queen_Yellow.byteArrayToImage() },
            { PieceType.Rook, Properties.Resources.Rook_Yellow.byteArrayToImage() },
            { PieceType.Knight, Properties.Resources.Knight_Yellow.byteArrayToImage() },
            { PieceType.Bishop, Properties.Resources.Bishop_Yellow.byteArrayToImage() },
            { PieceType.Pawn, Properties.Resources.Pawn_Yellow.byteArrayToImage() },
            { PieceType.PromotedQueen, Properties.Resources.Queen_Yellow.byteArrayToImage() },
            { PieceType.PromotedRook, Properties.Resources.Rook_Yellow.byteArrayToImage() },
            { PieceType.PromotedKnight, Properties.Resources.Knight_Yellow.byteArrayToImage() },
            { PieceType.PromotedBishop, Properties.Resources.Bishop_Yellow.byteArrayToImage() },
        };
        private static readonly Dictionary<PieceType, Image> _blueImages = new Dictionary<PieceType, Image>
        {
            { PieceType.King, Properties.Resources.King_Blue.byteArrayToImage() },
            { PieceType.Queen, Properties.Resources.Queen_Blue.byteArrayToImage() },
            { PieceType.Rook, Properties.Resources.Rook_Blue.byteArrayToImage() },
            { PieceType.Knight, Properties.Resources.Knight_Blue.byteArrayToImage() },
            { PieceType.Bishop, Properties.Resources.Bishop_Blue.byteArrayToImage() },
            { PieceType.Pawn, Properties.Resources.Pawn_Blue.byteArrayToImage() },
            { PieceType.PromotedQueen, Properties.Resources.Queen_Blue.byteArrayToImage() },
            { PieceType.PromotedRook, Properties.Resources.Rook_Blue.byteArrayToImage() },
            { PieceType.PromotedKnight, Properties.Resources.Knight_Blue.byteArrayToImage() },
            { PieceType.PromotedBishop, Properties.Resources.Bishop_Blue.byteArrayToImage() },
        };

        private static readonly Dictionary<PieceType, int> _piecePoints = new Dictionary<PieceType, int>
        {
            { PieceType.King, 20 },
            { PieceType.Queen, 9 },
            { PieceType.Rook, 5 },
            { PieceType.Knight, 3 },
            { PieceType.Bishop, 5 },
            { PieceType.Pawn, 1 },
            { PieceType.PromotedQueen, 1 },
            { PieceType.PromotedRook, 1 },
            { PieceType.PromotedKnight, 1 },
            { PieceType.PromotedBishop, 1 },
        };

        public static Image GetImage(this PlayerColor color, PieceType type)
        {
            return color switch
            {
                PlayerColor.White => _whiteImages[type],
                PlayerColor.Black => _blackImages[type],
                PlayerColor.Red => _redImages[type],
                PlayerColor.Green => _greenImages[type],
                PlayerColor.Yellow => _yellowImages[type],
                PlayerColor.Blue => _blueImages[type],
                _ => Properties.Resources.EmptyPiece.byteArrayToImage()
            };
        }

        public static Image GetImage(this PieceType piece, PlayerColor color)
            => color.GetImage(piece);

        private static Image byteArrayToImage(this byte[] byteArrayIn)
        {
            try
            {
                using (var ms = new MemoryStream(byteArrayIn))
                {
                    return Image.FromStream(ms);
                }
            }
            catch
            {
                return null;
            }
        }

        public static int GetPiecePoints(this PieceType piece)
            => _piecePoints[piece];
    }
}
