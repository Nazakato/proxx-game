using Proxx.Core.BoardGeneration;
using Proxx.Core.Enitites;

namespace Proxx.Core.Square
{
    public class BoardGenerationStrategy : IBoardGenerationStrategy<Board, BoardConfiguration>
    {
        public IHolesDistributionStrategy HolesDistributionStrategy { get; init; }

        public BoardGenerationStrategy(IHolesDistributionStrategy holesDistributionStrategy)
        {
            HolesDistributionStrategy = holesDistributionStrategy;
        }

        public Board Generate(BoardConfiguration boardConfiguration)
        {
            var cells = new Cell[boardConfiguration.FieldHeight, boardConfiguration.FieldWidth];
            using var allCells = HolesDistributionStrategy.GenerateHolesAmongEmptyCells(
                boardConfiguration.TotalCells, boardConfiguration.Holes).GetEnumerator();

            for (var i = 0; i < boardConfiguration.FieldHeight; i++)
            {
                for (var j = 0; j < boardConfiguration.FieldWidth; j++)
                {
                    if (allCells.MoveNext())
                        cells[i, j] = new Cell(allCells.Current);
                }
            }

            FillNumberCells(cells);

            return new Board(cells, boardConfiguration.TotalCells);
        }

        private static void FillNumberCells(Cell[,] cells)
        {
            for (int row = 0; row < cells.GetLength(0); row++)
            {
                for (int col = 0; col < cells.GetLength(1); col++)
                {
                    if (cells[row, col].Value == CellValue.Empty)
                    {
                        var surroindingHolesCount = CountSurroundingHoles(cells, row, col);
                        if (surroindingHolesCount != 0)
                            cells[row, col] = new Cell(CellValue.GetNumber(surroindingHolesCount));
                    }
                }
            }
        }

        private static int CountSurroundingHoles(Cell[,] cells, int row, int col)
        {
            var count = 0;

            if (IsValidCell(cells, row - 1, col - 1) && cells[row - 1, col - 1].IsHole()) count++;
            if (IsValidCell(cells, row - 1, col) && cells[row - 1, col].IsHole()) count++;
            if (IsValidCell(cells, row - 1, col + 1) && cells[row - 1, col + 1].IsHole()) count++;

            if (IsValidCell(cells, row, col - 1) && cells[row, col - 1].IsHole()) count++;
            if (IsValidCell(cells, row, col + 1) && cells[row, col + 1].IsHole()) count++;

            if (IsValidCell(cells, row + 1, col - 1) && cells[row + 1, col - 1].IsHole()) count++;
            if (IsValidCell(cells, row + 1, col) && cells[row + 1, col].IsHole()) count++;
            if (IsValidCell(cells, row + 1, col + 1) && cells[row + 1, col + 1].IsHole()) count++;

            return count;
        }

        private static bool IsValidCell(Cell[,] cells, int row, int col)
        {
            return row >= 0 && col >= 0 && row < cells.GetLength(0) && col < cells.GetLength(1);
        }
    }
}