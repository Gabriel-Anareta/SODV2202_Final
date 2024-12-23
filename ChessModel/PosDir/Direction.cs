﻿
namespace ChessModel
{
    /// <summary>
    /// Represents a change to a position given by a change in file and change in rank
    /// </summary>
    public class Direction(int fileDelta, int rankDelta)
    {
        public static readonly Direction North = new Direction(0, 1);
        public static readonly Direction East = new Direction(1, 0);
        public static readonly Direction South = -1 * North;
        public static readonly Direction West = -1 * East;
        public static readonly Direction NorthEast = North + East;
        public static readonly Direction NorthWest = North + West;
        public static readonly Direction SouthEast = South + East;
        public static readonly Direction SouthWest = South + West;

        public int FileDelta { get; set; } = fileDelta;
        public int RankDelta { get; set; } = rankDelta;

        public override bool Equals(object? obj)
        {
            return obj is Direction direction &&
                   FileDelta == direction.FileDelta &&
                   RankDelta == direction.RankDelta;
        }

        public static bool operator ==(Direction? left, Direction? right)
        {
            return EqualityComparer<Direction>.Default.Equals(left, right);
        }

        public static bool operator !=(Direction? left, Direction? right)
        {
            return !(left == right);
        }

        /// <summary>
        /// overloaded + operation on direction
        /// </summary>
        /// <param name="dir1"></param>
        /// <param name="dir2"></param>
        /// <returns>A new direction with the two direction values</returns>
        public static Direction operator +(Direction dir1, Direction dir2)
        {
            return new Direction(dir1.FileDelta + dir2.FileDelta, dir1.RankDelta + dir2.RankDelta);
        }

        /// <summary>
        /// overloaded * operator on direction
        /// </summary>
        /// <param name="scalar"></param>
        /// <param name="dir"></param>
        /// <returns>A new scaled version of a direction</returns>
        public static Direction operator *(int scalar, Direction dir)
        {
            return new Direction(scalar * dir.FileDelta, scalar * dir.RankDelta);
        }

        public static Direction RelRight(Direction dir)
        {
            if (dir == Direction.North)
                return Direction.East;
            if (dir == Direction.East)
                return Direction.South;
            if (dir == Direction.South)
                return Direction.West;
            if (dir == Direction.West)
                return Direction.North;
            return new Direction(0, 0);
        }
    }
}
