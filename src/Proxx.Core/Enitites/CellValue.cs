namespace Proxx.Core.Enitites
{
    /// <summary>
    /// Represents the value of the cell.
    /// </summary>
    internal class CellValue
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
        private static readonly CellValue _empty = new(' ');
        private static readonly CellValue[] _numbers = Enumerable.Range(1, 8)
            .Select(i => new CellValue((char)i)).ToArray();

        internal static CellValue Hole => _hole;
        internal static CellValue Empty => _empty;
        internal static CellValue GetNumber(int minesAround) => _numbers[minesAround - 1];
    }
}