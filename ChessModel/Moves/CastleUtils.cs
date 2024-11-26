namespace ChessModel
{
    public static class CastleUtils
    {
        private static dynamic KSQS(this MoveType type, dynamic argKS, dynamic argQS)
            => type == MoveType.CastleKingSide ? argKS : argQS;

        public static string CastleTypeAsString(this MoveType type)
        {
            return type switch
            {
                MoveType.CastleKingSide => "KS",
                MoveType.CastleQueenSide => "QS"
            };
        }

        public static Direction CastleDir(this MoveType type, PlayerColor color)
        {
            return color switch
            {
                PlayerColor.White => type.KSQS(Direction.East, Direction.West),
                PlayerColor.Black => type.KSQS(Direction.East, Direction.West),
                PlayerColor.Red => type.KSQS(Direction.East, Direction.West),
                PlayerColor.Green => type.KSQS(Direction.North, Direction.South),
                PlayerColor.Yellow => type.KSQS(Direction.West, Direction.East),
                PlayerColor.Blue => type.KSQS(Direction.South, Direction.North),
                _ => throw new Exception("Ah yes...")
            };
        }

        public static Position KingTo(this MoveType type, PlayerColor color, Position kingPos)
        {
            return color switch
            {
                PlayerColor.White => type.KSQS(new Position(6, kingPos.Rank), new Position(2, kingPos.Rank)),
                PlayerColor.Black => type.KSQS(new Position(6, kingPos.Rank), new Position(2, kingPos.Rank)),
                PlayerColor.Red => type.KSQS(new Position(9, kingPos.Rank), new Position(5, kingPos.Rank)),
                PlayerColor.Green => type.KSQS(new Position(kingPos.File, 4), new Position(kingPos.File, 8)),
                PlayerColor.Yellow => type.KSQS(new Position(4, kingPos.Rank), new Position(8, kingPos.Rank)),
                PlayerColor.Blue => type.KSQS(new Position(kingPos.File, 9), new Position(kingPos.File, 5)),
                _ => throw new Exception("Ah yes...")
            };
        }

        public static Position RookPos(this MoveType type, PlayerColor color, Position kingPos)
        {
            return color switch
            {
                PlayerColor.White => type.KSQS(new Position(7, kingPos.Rank), new Position(0, kingPos.Rank)),
                PlayerColor.Black => type.KSQS(new Position(7, kingPos.Rank), new Position(0, kingPos.Rank)),
                PlayerColor.Red => type.KSQS(new Position(10, kingPos.Rank), new Position(3, kingPos.Rank)),
                PlayerColor.Green => type.KSQS(new Position(kingPos.File, 3), new Position(kingPos.File, 10)),
                PlayerColor.Yellow => type.KSQS(new Position(10, kingPos.Rank), new Position(3, kingPos.Rank)),
                PlayerColor.Blue => type.KSQS(new Position(kingPos.File, 3), new Position(kingPos.File, 10)),
                _ => throw new Exception("Ah yes...")
            };
        }

        public static Position RookTo(this MoveType type, PlayerColor color, Position kingPos)
        {
            return color switch
            {
                PlayerColor.White => type.KSQS(new Position(5, kingPos.Rank), new Position(3, kingPos.Rank)),
                PlayerColor.Black => type.KSQS(new Position(5, kingPos.Rank), new Position(3, kingPos.Rank)),
                PlayerColor.Red => type.KSQS(new Position(8, kingPos.Rank), new Position(6, kingPos.Rank)),
                PlayerColor.Green => type.KSQS(new Position(kingPos.File, 5), new Position(kingPos.File, 7)),
                PlayerColor.Yellow => type.KSQS(new Position(5, kingPos.Rank), new Position(7, kingPos.Rank)),
                PlayerColor.Blue => type.KSQS(new Position(kingPos.File, 8), new Position(kingPos.File, 6)),
                _ => throw new Exception("Ah yes...")
            };
        }

        public static List<Position> BetweenPos(this MoveType type, PlayerColor color, Position kingPos)
        {
            return color switch
            {
                PlayerColor.White => type.KSQS(
                    new List<Position> { new(5, kingPos.Rank), new(6, kingPos.Rank) },
                    new List<Position> { new(1, kingPos.Rank), new(2, kingPos.Rank), new(3, kingPos.Rank) }
                ),
                PlayerColor.Black => type.KSQS(
                    new List<Position> { new(5, kingPos.Rank), new(6, kingPos.Rank) },
                    new List<Position> { new(1, kingPos.Rank), new(2, kingPos.Rank), new(3, kingPos.Rank) }
                ),
                PlayerColor.Red => type.KSQS(
                    new List<Position> { new(8, kingPos.Rank), new(9, kingPos.Rank) },
                    new List<Position> { new(4, kingPos.Rank), new(5, kingPos.Rank), new(6, kingPos.Rank) }
                ),
                PlayerColor.Green => type.KSQS(
                    new List<Position> { new(kingPos.File, 4), new(kingPos.File, 5) },
                    new List<Position> { new(kingPos.File, 7), new(kingPos.File, 8), new(kingPos.File, 9) }
                ),
                PlayerColor.Yellow => type.KSQS(
                    new List<Position> { new(4, kingPos.Rank), new(5, kingPos.Rank) },
                    new List<Position> { new(7, kingPos.Rank), new(8, kingPos.Rank), new(9, kingPos.Rank) }
                ),
                PlayerColor.Blue => type.KSQS(
                    new List<Position> { new(kingPos.File, 8), new(kingPos.File, 9) },
                    new List<Position> { new(kingPos.File, 4), new(kingPos.File, 5), new(kingPos.File, 6) }
                ),
                _ => throw new Exception("Ah yes...")
            };
        }
    }
}
