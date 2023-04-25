using Proxx.Core.Configuration;
using Proxx.Core.Enitites;

namespace Proxx.Core.BoardGeneration
{
    /// <summary>
    /// This interface of board factory, allows to inject the strategy of filling the board on initialization.
    /// </summary>
    public interface IBoardGenerationStrategy<TBoard, TBoardConfiguration>
        where TBoard : BaseBoard
        where TBoardConfiguration : BaseBoardConfiguration
    {
        IHolesDistributionStrategy HolesDistributionStrategy { get; init; }
        TBoard Generate(TBoardConfiguration boardconfiguration);
    }
}