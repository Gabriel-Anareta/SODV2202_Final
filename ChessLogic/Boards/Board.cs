using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
        protected bool IsEmptyPosition(Position pos)
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

        public event NotifyCollectionChangedEventHandler? CollectionChanged;
        protected void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
            => CollectionChanged?.Invoke(this, e);
    }
}
