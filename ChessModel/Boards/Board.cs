namespace ChessModel
{
    /// <summary>
    /// Implements base board functionality and properties
    /// </summary>
    public abstract class Board
    {
        public abstract int FILES { get; }
        public abstract int RANKS { get; }
        public abstract Binding2DArray<Piece> Pieces { get; set; }

        protected Dictionary<PlayerColor, Move> _enPassantSquares;

        /// <summary>
        /// Allows referencing of the board pieces like an array
        /// </summary>
        /// <param name="file"></param>
        /// <param name="rank"></param>
        /// <returns>Piece at the given file and rank</returns>
        public Piece this[int file, int rank]
        {
            get { return Pieces[file, rank]; }
            set 
            {
                if (Pieces[file, rank] == value)
                    return;
                Pieces[file, rank] = value;
            }
        }

        /// <summary>
        /// Allows referencing of the board using a position
        /// </summary>
        /// <param name="pos"></param>
        /// <returns>Piece at the given position</returns>
        public Piece this[Position pos]
        {
            get { return this[pos.File, pos.Rank]; }
            set 
            {
                if (this[pos.File, pos.Rank] == value)
                    return;
                this[pos.File, pos.Rank] = value;
            }
        }

        /// <summary>
        /// Checks whether a position is in the valid bounds of the board
        /// </summary>
        /// <param name="pos"></param>
        /// <returns>True if the given position is in the valid bounds of the board</returns>
        public abstract bool IsValidPosition(Position pos);

        /// <summary>
        /// Checks whether a position holds an empty(null) value
        /// </summary>
        /// <param name="pos"></param>
        /// <returns>True if the given position references a null value</returns>
        public bool IsEmptyPosition(Position pos)
            => this[pos].Type == PieceType.None;

        /// <summary>
        /// Creates a copy of the current board
        /// </summary>
        /// <returns>A new board with the copied positions of the pieces held by the original board</returns>
        public abstract Board Copy();

        /// <summary>
        /// Gets the EnPassantSquare for a given player
        /// </summary>
        /// <param name="color"></param>
        /// <returns>Position identified by color</returns>
        public Move GetEnPassantMove(PlayerColor color)
            => _enPassantSquares[color];

        /// <summary>
        /// Sets the EnPassanSquare for a given color
        /// </summary>
        /// <param name="color"></param>
        /// <param name="pos"></param>
        public void SetEnPassantSquare(PlayerColor color, Move move)
            => _enPassantSquares[color] = move;

        /// <summary>
        /// Checks if a player is in check
        /// </summary>
        /// <param name="player"></param>
        /// <returns>Returns true if the given player is in check</returns>
        public bool IsInCheck(PlayerColor player)
        {
            foreach (PlayerColor opponent in player.Opponents())
                if (PiecePositionsFor(opponent).Any(pos => this[pos].CanCaptureOpponentKing(pos, this, player)))
                    return true;
            return false;
        }

        /// <summary>
        /// Gets positions of all the pieces that a player currently has in play
        /// </summary>
        /// <param name="player"></param>
        /// <returns>An IEnumerable that holds the positions of all the pieces that a player currently has in play</returns>
        public IEnumerable<Position> PiecePositionsFor(PlayerColor player)
            => PiecePositions().Where(pos => this[pos].Color == player);

        /// <summary>
        /// Gets positions of all pieces on the board
        /// </summary>
        /// <returns>An IEnumerable that holds the positions of all the pieces</returns>
        protected IEnumerable<Position> PiecePositions()
        {
            for (int file = 0; file < FILES; file++)
            {
                for (int rank = 0; rank < RANKS; rank++)
                {
                    Position pos = new Position(file, rank);
                    if (!IsEmptyPosition(pos))
                        yield return pos;
                }
            }
        }

        public PieceCount CountPieces()
        {
            PieceCount count = GenerateCounter();

            foreach (Position pos in PiecePositions())
                count.IncrementPieceCount(this[pos].Color, this[pos].Type);

            return count;
        }

        protected abstract PieceCount GenerateCounter();

        public bool InsufficientMaterial()
        {
            PieceCount count = CountPieces();

            return (
                IsKingVKing(count)
                || IsKingBishopVKing(count)
                || IsKingKnightVKing(count)
                || IsKingBishopVKingBishop(count)
            );
        }

        private bool IsKingVKing(PieceCount count)
            => count.TotalPieces == 2;

        private bool IsKingBishopVKing(PieceCount count)
            => count.TotalPieces == 3 && count.Any(PieceType.Bishop, count => count == 1);
            
        private bool IsKingKnightVKing(PieceCount count)
            => count.TotalPieces == 3 && count.Any(PieceType.Knight, count => count == 1);

        private bool IsKingBishopVKingBishop(PieceCount count)
        {
            if (count.TotalPieces != 4) 
                return false;

            if (count.Any(PieceType.Bishop, count => count != 1))
                return false;

            if (count.Any(PieceType.King, count => count != 1))
                return false;

            List<Position> typePos = AllPiecePos(PieceType.Bishop);
            if (typePos.Count != 2)
                return false;

            return typePos[0].SquareColor() == typePos[1].SquareColor();
        }

        protected Position FindPiece(PlayerColor color, PieceType type)
            => PiecePositionsFor(color).First(pos => this[pos].Type == type);

        protected abstract List<Position> AllPiecePos(PieceType type);
    }
}
