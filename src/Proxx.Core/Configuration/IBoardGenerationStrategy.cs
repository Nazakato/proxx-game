using Proxx.Core.Enitites;

namespace Proxx.Core.Configuration
{
    /// <summary>
    /// This interface of board factory, allows to inject the strategy of filling the board on initialization.
    /// </summary>
    public interface IBoardGenerationStrategy
    {
        Board Generate(BoardConfiguration boardconfiguration);
    }
}