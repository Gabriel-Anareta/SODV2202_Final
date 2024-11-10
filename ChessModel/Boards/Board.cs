﻿using System.Collections.Specialized;

namespace ChessModel
{
    /// <summary>
    /// Implements base board functionality and properties
    /// </summary>
    public abstract class Board : INotifyCollectionChanged
    {
        public abstract int FILES { get; }
        public abstract int RANKS { get; }
        public abstract Piece?[,] Pieces { get; }

        protected Dictionary<PlayerColor, Position> _enPassantSquares;

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
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace));
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
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace));
            }
        }
        
        /// <summary>
        /// Initializes the board with the starting positions of pieces
        /// </summary>
        /// <returns>A new board with all initialized pieces</returns>
        public abstract Board InitialState();

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
            => this[pos] == null;

        /// <summary>
        /// Creates a copy of the current board
        /// </summary>
        /// <returns>A new board with the copied positions of the pieces held by the original board</returns>
        public abstract Board Copy();

        /// <summary>
        /// Creates a Fen string from the current board
        /// </summary>
        /// <returns>A string formatted with the respective Fen form of the board</returns>
        public abstract string BoardToFen();

        /// <summary>
        /// Gets the EnPassantSquare for a given player
        /// </summary>
        /// <param name="color"></param>
        /// <returns>Position identified by color</returns>
        public Position GetEnPassantSquare(PlayerColor color)
            => _enPassantSquares[color];

        /// <summary>
        /// Sets the EnPassanSquare for a given color
        /// </summary>
        /// <param name="color"></param>
        /// <param name="pos"></param>
        public void SetEnPassantSquare(PlayerColor color, Position pos)
            => _enPassantSquares[color] = pos;

        /// <summary>
        /// Checks if a player is in check
        /// </summary>
        /// <param name="player"></param>
        /// <returns>Returns true if the given player is in check</returns>
        public bool IsInCheck(PlayerColor player)
            => PiecePositionsFor(player)
                .Any(pos => this[pos].CanCaptureOpponentKing(pos, this));

        /// <summary>
        /// Gets positions of all the pieces that a player currently has in play
        /// </summary>
        /// <param name="player"></param>
        /// <returns>An IEnumerable that holds the positions of all the pieces that a player currently has in play</returns>
        internal IEnumerable<Position> PiecePositionsFor(PlayerColor player)
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

        public event NotifyCollectionChangedEventHandler? CollectionChanged;
        protected void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
            => CollectionChanged?.Invoke(this, e);
    }
}