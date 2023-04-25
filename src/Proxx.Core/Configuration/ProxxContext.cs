using Proxx.Core.BoardGeneration;
using Proxx.Core.Enitites;

namespace Proxx.Core.Configuration
{
    /// <summary>
    /// This classs is an entry point for the game runner logic.
    /// </summary>
    public class ProxxContext<TBoard, TBoardConfiguration>
        where TBoard : BaseBoard
        where TBoardConfiguration : BaseBoardConfiguration
    {
        private readonly IBoardGenerationStrategy<TBoard, TBoardConfiguration> _boardGenerationStrategy;
        public TBoardConfiguration BoardConfiguration { get; init; }
        public TBoard Board { get; init; }

        public ProxxContext(TBoardConfiguration boardconfiguration,
            IBoardGenerationStrategy<TBoard, TBoardConfiguration> boardGenerationStrategy)
        {
            BoardConfiguration = boardconfiguration ?? throw new ArgumentNullException(nameof(boardconfiguration));
            _boardGenerationStrategy = boardGenerationStrategy ?? throw new ArgumentNullException(nameof(boardGenerationStrategy));

            Board = _boardGenerationStrategy.Generate(boardconfiguration);
        }
    }
}