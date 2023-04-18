namespace Proxx.Core.Enitites
{
    /// <summary>
    /// The aggregate for all the cells on the board.
    /// </summary>
    public class Board
    {
        /// <summary>
        /// The datastructure chosen is a 2-dimensional array because:
        /// - there is a need to track all the "Holes" and "Numbers", and this would take the most part of this array;
        /// - some kind of sparse array could be used for space efficience, for the edge case when amount of "Holes" is very low in comparison to the board size (Height * Width)
        /// - sparse array would also make sense if there was a need to support huge boards (millions of cells).
        /// </summary>
        private readonly Cell[,] _cells;

        internal Board(Cell[,] cells)
        {
            _cells = cells ?? throw new ArgumentNullException(nameof(cells));
        }

        public void Open(Position position)
        {
            // find & open cell
        }
    }
}