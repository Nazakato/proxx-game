namespace Proxx.Core.Configuration
{
    /// <summary>
    /// This class contains all the needed configurations for board generation.
    /// </summary>
    public abstract class BaseBoardConfiguration
    {
        public int Holes { get; init; }
        public int TotalCells { get; init; }

        public BaseBoardConfiguration(int totalCells, int holes)
        {
            if (totalCells < 0) throw new ApplicationException($"{nameof(totalCells)} can't be less than 0.");
            if (holes < 0) throw new ApplicationException($"{nameof(holes)} can't be less than 0.");
            if (holes > totalCells) throw new ApplicationException($"{nameof(holes)} can't be more than {nameof(totalCells)}");

            TotalCells = totalCells;
            Holes = holes;
        }
    }
}