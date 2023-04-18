namespace Proxx.Core.Enitites
{
    internal class Cell
    {
        internal Position Position { get; init; }
        internal CellValue Value { get; init; }
        internal bool IsOpen { get; private set; }

        internal Cell(Position position, CellValue cellValue, bool isOpen = false)
        {
            Position = position;
            Value = cellValue;
            IsOpen = isOpen;
        }

        internal void Open()
        {
            IsOpen = true;
        }
    }
}