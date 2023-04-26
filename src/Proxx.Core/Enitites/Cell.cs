namespace Proxx.Core.Enitites
{
    public class Cell
    {
        private const string ClosedCellValue = "X";

        public CellValue Value { get; init; }
        public bool IsOpen { get; private set; }

        public Cell(CellValue cellValue, bool isOpen = false)
        {
            Value = cellValue;
            IsOpen = isOpen;
        }

        public override string ToString()
        {
            return IsOpen ? Value.ToString() : ClosedCellValue;
        }

        public void Open()
        {
            IsOpen = true;
        }

        public bool IsHole()
        {
            return Value == CellValue.Hole;
        }

        public bool IsEmpty()
        {
            return Value == CellValue.Empty;
        }
    }
}