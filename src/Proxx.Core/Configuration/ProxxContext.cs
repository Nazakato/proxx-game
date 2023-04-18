using Proxx.Core.Enitites;

namespace Proxx.Core.Configuration
{
    /// <summary>
    /// This classs is an entry point for the game runner logic.
    /// </summary>
    public class ProxxContext
    {
        private readonly IBoardGenerationStrategy _boardGenerationStrategy;
        private readonly BoardConfiguration _boardConfiguration;
        private readonly Board _board;

        public ProxxContext(BoardConfiguration boardconfiguration, IBoardGenerationStrategy boardGenerationStrategy)
        {
            _boardConfiguration = boardconfiguration ?? throw new ArgumentNullException(nameof(boardconfiguration));
            _boardGenerationStrategy = boardGenerationStrategy ?? throw new ArgumentNullException(nameof(boardGenerationStrategy));

            _board = _boardGenerationStrategy.Generate(boardconfiguration);
        }
    }
}