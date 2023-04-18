namespace Proxx.Core.Configuration
{
    /// <summary>
    /// This class contains all the needed configurations for board generation.
    /// </summary>
    public class BoardConfiguration
    {
        public int FieldWidth { get; init; }
        public int FieldHeight { get; init; }
        public int Holes { get; init; }
    }
}