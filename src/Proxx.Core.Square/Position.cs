using System.Diagnostics.CodeAnalysis;
using Proxx.Core.Enitites;

namespace Proxx.Core.Square
{
    public class Position : BasePosition
    {
        public int Row { get; private set; }
        public int Col { get; private set; }

        public Position() { }

        public static Position Create(int row, int col) => new() { Row = row, Col = col };

        public override string ToString()
        {
            return $"[Row: {Row}, Col: {Col}]";
        }
    }
}
