using Proxx.Core.BoardGeneration;
using Proxx.Core.Enitites;

namespace Proxx.Core.Configuration
{
    /// <summary>
    /// This classs is an entry point for the game runner logic.
    /// </summary>
    public class ProxxContext<TBoard, TPosition, TBoardConfiguration>
        where TPosition : BasePosition
        where TBoard : BaseBoard<TPosition>
        where TBoardConfiguration : BaseBoardConfiguration
    {
        private readonly IBoardGenerationStrategy<TBoard, TPosition, TBoardConfiguration> _boardGenerationStrategy;
        private readonly TBoard _board;
        private TPosition? _lastMove;
        public GameState GameState { get; private set; }
        public TBoardConfiguration BoardConfiguration { get; init; }

        public ProxxContext(TBoardConfiguration boardconfiguration,
            IBoardGenerationStrategy<TBoard, TPosition, TBoardConfiguration> boardGenerationStrategy)
        {
            BoardConfiguration = boardconfiguration ?? throw new ArgumentNullException(nameof(boardconfiguration));
            _boardGenerationStrategy = boardGenerationStrategy ?? throw new ArgumentNullException(nameof(boardGenerationStrategy));

            GameState = GameState.Ongoing;
            _board = _boardGenerationStrategy.Generate(boardconfiguration);
        }

        public virtual void OpenBoardAt(TPosition position)
        {
            if (GameState != GameState.Ongoing) return;

            _lastMove = position;
            if (!_board.OpenCell(position))
                GameState = GameState.GameOver;
            else if (WinCondition())
                GameState = GameState.GameWon;
        }

        protected virtual bool WinCondition()
        {
            return _board.OnlyHolesClosed();
        }

        public override string ToString()
        {
            var str = $"Game state: {GameState}";
            if (_lastMove is not null) str += $", last move: {_lastMove}";
            str += $".{Environment.NewLine}{_board}";
            return str;
        }
    }
}