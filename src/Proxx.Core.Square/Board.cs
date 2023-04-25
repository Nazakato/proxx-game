using System.Text;
using Proxx.Core.Enitites;

namespace Proxx.Core.Square
{
    public class Board : BaseBoard
    {
        /// <summary>
        /// The datastructure chosen is a 2-dimensional array because:
        /// - there is a need to track all the "Holes" and "Numbers", and this would take the most part of this array;
        /// - some kind of sparse array could be used for space efficience, for the edge case when amount of "Holes" is very low in comparison to the board size (Height * Width)
        /// - sparse array would also make sense if there was a need to support huge boards (millions of cells).
        /// </summary>
        private readonly Cell[,] _cells;

        public Board(Cell[,] cells, int holes) : base(cells.GetLength(0) * cells.GetLength(1), holes)
        {
            _cells = cells;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < _cells.GetLength(0); i++)
            {
                for (int j = 0; j < _cells.GetLength(1); j++)
                {
                    sb.Append(' ');
                    sb.Append(_cells[i, j].ToString());
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}