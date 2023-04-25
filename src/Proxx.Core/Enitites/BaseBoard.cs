namespace Proxx.Core.Enitites
{
    /// <summary>
    /// The aggregate for all the cells on the board.
    /// </summary>
    public abstract class BaseBoard
    {
        public int CellsCount { get; init; }
        public int HolesCount { get; init; }

        public BaseBoard(int cellsCount, int holesCount)
        {
            if (cellsCount < 0) throw new ApplicationException($"{nameof(cellsCount)} can't be less than 0.");
            if (holesCount < 0) throw new ApplicationException($"{nameof(holesCount)} can't be less than 0.");
            if (holesCount > cellsCount) throw new ApplicationException($"{nameof(holesCount)} can't be more than {nameof(cellsCount)}");

            CellsCount = cellsCount;
            HolesCount = holesCount;
        }
    }
}