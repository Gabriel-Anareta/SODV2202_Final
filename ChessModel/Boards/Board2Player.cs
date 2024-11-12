using System.ComponentModel;

namespace ChessModel
{
    /// <summary>
    /// Represents a classic 8x8 chess board
    /// </summary>
    public class Board2Player : Board
    {
        public override int FILES => 8;
        public override int RANKS => 8;
        public override Binding2DArray<Piece> Pieces { get; set; }

        public Board2Player()
        {
            Pieces = new Binding2DArray<Piece>(FILES, RANKS, new EmptyPiece());
            _enPassantSquares = new Dictionary<PlayerColor, Position>
            {
                { PlayerColor.White, null },
                { PlayerColor.Black, null }
            };
        }

        public override Board InitialState()
        {
            Board2Player board = new Board2Player();
            board = AddStartPieces(board);
            return board;
        }

        private Board2Player AddStartPieces(Board2Player board)
        {
            board[0, 0] = new Rook(PlayerColor.White);
            board[1, 0] = new Knight(PlayerColor.White);
            board[2, 0] = new Bishop(PlayerColor.White);
            board[3, 0] = new Queen(PlayerColor.White);
            board[4, 0] = new King(PlayerColor.White);
            board[5, 0] = new Bishop(PlayerColor.White);
            board[6, 0] = new Knight(PlayerColor.White);
            board[7, 0] = new Rook(PlayerColor.White);

            board[0, 7] = new Rook(PlayerColor.Black);
            board[1, 7] = new Knight(PlayerColor.Black);
            board[2, 7] = new Bishop(PlayerColor.Black);
            board[3, 7] = new Queen(PlayerColor.Black);
            board[4, 7] = new King(PlayerColor.Black);
            board[5, 7] = new Bishop(PlayerColor.Black);
            board[6, 7] = new Knight(PlayerColor.Black);
            board[7, 7] = new Rook(PlayerColor.Black);

            for (int file = 0; file < board.FILES; file++)
            {
                board[file, 1] = new Pawn(PlayerColor.White);
                board[file, 6] = new Pawn(PlayerColor.Black);
            }

            return board;
        }

        public override bool IsValidPosition(Position pos)
        {
            return
                pos.File >= 0
                && pos.File < FILES
                && pos.Rank >= 0
                && pos.Rank < RANKS;
        }

        public override Board Copy()
        {
            Board2Player copy = new Board2Player();

            foreach (Position pos in PiecePositions())
                copy[pos] = this[pos].Copy();

            return copy;
        }
    }
}
