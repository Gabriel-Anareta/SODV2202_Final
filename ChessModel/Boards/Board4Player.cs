namespace ChessModel
{
    public class Board4Player : Board
    {
        public override int FILES => 14;
        public override int RANKS => 14;
        public override Binding2DArray<Piece> Pieces { get; set; }

        public Board4Player()
        {
            Pieces = new Binding2DArray<Piece>(FILES, RANKS, new EmptyPiece());
            _enPassantSquares = new Dictionary<PlayerColor, Move>
            {
                { PlayerColor.Red, null },
                { PlayerColor.Green, null },
                { PlayerColor.Yellow, null },
                { PlayerColor.Blue, null }
            };
        }

        /// <summary>
        /// Initializes the board with the starting positions of pieces
        /// </summary>
        /// <returns>A new board with all initialized pieces</returns>
        public Board4Player InitialState()
        {
            Board4Player board = new Board4Player();
            board = AddStartPieces(board);
            return board;
        }

        private Board4Player AddStartPieces(Board4Player board)
        {
            board[3, 0] = new Rook(PlayerColor.Red);
            board[4, 0] = new Knight(PlayerColor.Red);
            board[5, 0] = new Bishop(PlayerColor.Red);
            board[6, 0] = new Queen(PlayerColor.Red);
            board[7, 0] = new King(PlayerColor.Red);
            board[8, 0] = new Bishop(PlayerColor.Red);
            board[9, 0] = new Knight(PlayerColor.Red);
            board[10, 0] = new Rook(PlayerColor.Red);

            board[3, 13] = new Rook(PlayerColor.Yellow);
            board[4, 13] = new Knight(PlayerColor.Yellow);
            board[5, 13] = new Bishop(PlayerColor.Yellow);
            board[6, 13] = new King(PlayerColor.Yellow);
            board[7, 13] = new Queen(PlayerColor.Yellow);
            board[8, 13] = new Bishop(PlayerColor.Yellow);
            board[9, 13] = new Knight(PlayerColor.Yellow);
            board[10, 13] = new Rook(PlayerColor.Yellow);

            board[0, 3] = new Rook(PlayerColor.Blue);
            board[0, 4] = new Knight(PlayerColor.Blue);
            board[0, 5] = new Bishop(PlayerColor.Blue);
            board[0, 6] = new Queen(PlayerColor.Blue);
            board[0, 7] = new King(PlayerColor.Blue);
            board[0, 8] = new Bishop(PlayerColor.Blue);
            board[0, 9] = new Knight(PlayerColor.Blue);
            board[0, 10] = new Rook(PlayerColor.Blue);

            board[13, 3] = new Rook(PlayerColor.Green);
            board[13, 4] = new Knight(PlayerColor.Green);
            board[13, 5] = new Bishop(PlayerColor.Green);
            board[13, 6] = new King(PlayerColor.Green);
            board[13, 7] = new Queen(PlayerColor.Green);
            board[13, 8] = new Bishop(PlayerColor.Green);
            board[13, 9] = new Knight(PlayerColor.Green);
            board[13, 10] = new Rook(PlayerColor.Green);

            for (int file = 3; file < board.FILES - 3; file++)
            {
                board[file, 1] = new Pawn(PlayerColor.Red);
                board[file, 12] = new Pawn(PlayerColor.Yellow);
            }

            for (int rank = 3; rank < board.FILES - 3; rank++)
            {
                board[1, rank] = new Pawn(PlayerColor.Blue);
                board[12, rank] = new Pawn(PlayerColor.Green);
            }

            return board;
        }

        public override bool IsValidPosition(Position pos)
        {
            return
                pos.File >= 0
                && pos.File < FILES
                && pos.Rank >= 0
                && pos.Rank < RANKS
                && !PositionInDeadSpace(pos);
        }

        public bool PositionInDeadSpace(Position pos)
        {
            if (NumInRange(pos.File, 0, 2) || NumInRange(pos.File, 11, 13))
                if (NumInRange(pos.Rank, 0, 2) || NumInRange(pos.Rank, 11, 13))
                    return true;

            return false;
        }

        private bool NumInRange(int num, int checkLeft, int checkRight)
            => num >= checkLeft && num <= checkRight;

        public override Board Copy()
        {
            Board4Player copy = new Board4Player();

            foreach (Position pos in PiecePositions())
                copy[pos] = this[pos].Copy();

            return copy;
        }

        protected override PieceCount GenerateCounter()
            => new PieceCount4P();

        protected override List<Position> AllPiecePos(PieceType type)
        {
            return (
                new List<Position>
                {
                    FindPiece(PlayerColor.Red, type),
                    FindPiece(PlayerColor.Green, type),
                    FindPiece(PlayerColor.Yellow, type),
                    FindPiece(PlayerColor.Blue, type)
                }
            );
        }
    }
}
