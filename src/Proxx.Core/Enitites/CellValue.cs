namespace Proxx.Core.Enitites
{
    /// <summary>
    /// Represents the value of the cell.
    /// </summary>
    public class CellValue
    {
        private readonly char _value;

        private CellValue(char value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return $"{_value}";
        }

        //  The class is made lightweight for 2 reasons:
        // - Restrict creating "custom" values.
        // - Reuse the objects in memory, as we ca fill a very large board. The more value objects will be reused, the better.
        private static readonly CellValue _hole = new('H');
        private static readonly CellValue _empty = new('-');
        private static readonly Dictionary<int, CellValue> _numbers = new();

        public static CellValue Hole => _hole;
        public static CellValue Empty => _empty;
        public static CellValue GetNumber(int minesAround)
        {
            if (_numbers.TryGetValue(minesAround, out var cellValue))
                return cellValue;

            cellValue = new CellValue((char)(minesAround + 48));
            _numbers[minesAround] = cellValue;
            return cellValue;
        }
    }
}