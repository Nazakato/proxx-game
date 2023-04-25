using Proxx.Core.Enitites;

namespace Proxx.Core.BoardGeneration
{
    public interface IHolesDistributionStrategy
    {
        /// <summary>
        /// Generates holes <paramref name="totalsCells"/>, <paramref name="holes"/> are holes, others empty.
        /// </summary>
        /// <param name="totalsCells"></param>
        /// <param name="holes"></param>
        /// <returns></returns>
        IEnumerable<CellValue> GenerateHolesAmongEmptyCells(int totalsCells, int holes);
    }
}