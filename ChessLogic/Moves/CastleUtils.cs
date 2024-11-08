using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel.Moves
{
    public static class CastleUtils
    {
        private static dynamic KSQS(this MoveType type, dynamic argKS, dynamic argQS)
            => type == MoveType.CastleKingSide ? argKS : argQS;

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
                PlayerColor.Red => throw new NotImplementedException(),
                PlayerColor.Green => throw new NotImplementedException(),
                PlayerColor.Yellow => throw new NotImplementedException(),
                PlayerColor.Blue => throw new NotImplementedException(),
                _ => throw new Exception("Ah yes...")
            };
        }

        public static Position RookPos(this MoveType type, PlayerColor color, Position kingPos)
        {
            return color switch
            {
                PlayerColor.White => type.KSQS(new Position(7, kingPos.Rank), new Position(0, kingPos.Rank)),
                PlayerColor.Black => type.KSQS(new Position(7, kingPos.Rank), new Position(0, kingPos.Rank)),
                PlayerColor.Red => throw new NotImplementedException(),
                PlayerColor.Green => throw new NotImplementedException(),
                PlayerColor.Yellow => throw new NotImplementedException(),
                PlayerColor.Blue => throw new NotImplementedException(),
                _ => throw new Exception("Ah yes...")
            };
        }

        public static Position RookTo(this MoveType type, PlayerColor color, Position kingPos)
        {
            return color switch
            {
                PlayerColor.White => type.KSQS(new Position(5, kingPos.Rank), new Position(3, kingPos.Rank)),
                PlayerColor.Black => new Position(3, kingPos.Rank),
                PlayerColor.Red => throw new NotImplementedException(),
                PlayerColor.Green => throw new NotImplementedException(),
                PlayerColor.Yellow => throw new NotImplementedException(),
                PlayerColor.Blue => throw new NotImplementedException(),
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
                PlayerColor.Red => throw new NotImplementedException(),
                PlayerColor.Green => throw new NotImplementedException(),
                PlayerColor.Yellow => throw new NotImplementedException(),
                PlayerColor.Blue => throw new NotImplementedException(),
                _ => throw new Exception("Ah yes...")
            };
        }
    }
}
