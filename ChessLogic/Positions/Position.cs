namespace ChessModel
{
    public class Position // represents a position given by a file and a rank
    {
        public int File { get; set; }   // columns
        public int Rank { get; set; }   // rows

        public Position(int file, int rank)
        {
            File = file;
            Rank = rank;
        }

        public PlayerColor SquareColor()
        {
            if ((File + Rank) % 2 == 0)
                return PlayerColor.White;

            return PlayerColor.Black;
        }

        public override bool Equals(object? obj)
        {
            return obj is Position position &&
                   File == position.File &&
                   Rank == position.Rank;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(File, Rank);
        }

        public static bool operator ==(Position? left, Position? right)
        {
            return EqualityComparer<Position>.Default.Equals(left, right);
        }

        public static bool operator !=(Position? left, Position? right)
        {
            return !(left == right);
        }
    }
}
