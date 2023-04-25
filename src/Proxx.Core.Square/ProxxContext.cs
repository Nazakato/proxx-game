using Proxx.Core.BoardGeneration;
using Proxx.Core.Configuration;

namespace Proxx.Core.Square
{
    public class ProxxContext : ProxxContext<Board, BoardConfiguration>
    {
        public ProxxContext(int fieldHeight, int fieldWidth, int holes,
            IHolesDistributionStrategy holesDistributionStrategy = null)
            : base(
                  new BoardConfiguration(fieldHeight, fieldWidth, holes), 
                  new BoardGenerationStrategy(
                      holesDistributionStrategy ?? new UniformHolesDistributionStrategy()))
        {
        }
    }
}
