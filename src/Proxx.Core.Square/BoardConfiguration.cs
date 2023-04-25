using Proxx.Core.Configuration;

namespace Proxx.Core.Square
{
    public class BoardConfiguration : BaseBoardConfiguration
    {
        public BoardConfiguration(int fieldHeight, int fieldWidth, int holes)
            : base(fieldHeight * fieldWidth, holes)
        {
            FieldHeight = fieldHeight;
            FieldWidth = fieldWidth;
        }

        public int FieldHeight { get; init; }
        public int FieldWidth { get; init; }
    }
}