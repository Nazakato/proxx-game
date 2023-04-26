using System.Linq;
using System.Text;
using Proxx.Core.Enitites;

namespace Proxx.Core.Square
{
    public class Board : BaseBoard<Position>
    {
        /// <summary>
        /// The datastructure chosen is a 2-dimensional array because:
        /// - there is a need to track all the "Holes" and "Numbers", and this would take the most part of this array;
        /// - some kind of sparse array could be used for space efficience, for the edge case when amount of "Holes" is very low in comparison to the board size (Height * Width)
        /// - sparse array would also make sense if there was a need to support huge boards (millions of cells).
        /// </summary>
        private readonly Cell[,] _cells;

        public Board(Cell[,] cells) : base()
        {
            _cells = cells;
        }

        public override bool OpenCell(Position position)
        {
            if (_cells[position.Row, position.Col].IsOpen) return true;

            if (_cells[position.Row, position.Col].IsHole())
            {
                _cells[position.Row, position.Col].Open();
                return false;
            }
            else
            {
                OpenWithNeighborCells(position);
                return true;
            }
        }

        private void OpenWithNeighborCells(Position position)
        {
            // Use Breadth-First Search algorithm
            var positionsToVisit = new Queue<Position>();
            positionsToVisit.Enqueue(position);

            while (positionsToVisit.TryDequeue(out var p))
            {
                if (IsValidPosition(p, _cells) && !_cells[p.Row, p.Col].IsOpen)
                {
                    _cells[p.Row, p.Col].Open();

                    if (_cells[p.Row, p.Col].IsEmpty())
                    {
                        positionsToVisit.Enqueue(Position.Create(p.Row + 1, p.Col));
                        positionsToVisit.Enqueue(Position.Create(p.Row + 1, p.Col - 1));
                        positionsToVisit.Enqueue(Position.Create(p.Row + 1, p.Col + 1));

                        positionsToVisit.Enqueue(Position.Create(p.Row, p.Col + 1));
                        positionsToVisit.Enqueue(Position.Create(p.Row, p.Col - 1));

                        positionsToVisit.Enqueue(Position.Create(p.Row - 1, p.Col));
                        positionsToVisit.Enqueue(Position.Create(p.Row - 1, p.Col - 1));
                        positionsToVisit.Enqueue(Position.Create(p.Row - 1, p.Col + 1));
                    }
                }
            }
        }

        private static bool IsValidPosition(Position p, Cell[,] cells)
        {
            return p.Row >= 0 && p.Row < cells.GetLength(0) && p.Col >= 0 && p.Col < cells.GetLength(1);
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

        public override bool OnlyHolesClosed()
        {
            for (int i = 0; i < _cells.GetLength(0); i++)
            {
                for (int j = 0; j < _cells.GetLength(1); j++)
                {
                    if (!_cells[i, j].IsOpen && !_cells[i, j].IsHole()) return false;
                }
            }
            return true;
        }
    }
}