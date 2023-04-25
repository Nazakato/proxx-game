using Proxx.Core.Enitites;

namespace Proxx.Core.BoardGeneration
{
    public class UniformHolesDistributionStrategy : IHolesDistributionStrategy
    {
        // Add possibility to seed the field for testing purposes
        private readonly int? _seed;
        public UniformHolesDistributionStrategy(int? seed = null)
        {
            _seed = seed;
        }

        public IEnumerable<CellValue> GenerateHolesAmongEmptyCells(int totalCells, int holesCount)
        {
            // generate needed amount of holes, others empty
            var cells = Enumerable.Repeat(CellValue.Hole, holesCount)
                .Concat(Enumerable.Repeat(CellValue.Empty, totalCells - holesCount))
                .ToList();

            // mix up with uniform distribution
            var random = _seed.HasValue ? new Random(_seed.Value) : new Random();
            for (int i = 0; i < holesCount; i++)
            {
                var swapWithIndex = random.Next(0, totalCells);
                Swap(cells, i, swapWithIndex);
            }

            return cells;
        }

        private void Swap(List<CellValue> cells, int thisIndex, int anotherIndex)
        {
            var tmp = cells[thisIndex];
            cells[thisIndex] = cells[anotherIndex];
            cells[anotherIndex] = tmp;
        }
    }
}
