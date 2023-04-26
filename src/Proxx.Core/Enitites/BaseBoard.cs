namespace Proxx.Core.Enitites
{
    /// <summary>
    /// The aggregate for all the cells on the board.
    /// </summary>
    public abstract class BaseBoard<TPosition>
        where TPosition : BasePosition
    {
        public BaseBoard() { }

        /// <summary>
        /// Opens the cell
        /// </summary>
        /// <param name="position"></param>
        /// <returns>False if mine opened, true otherwise</returns>
        public abstract bool OpenCell(TPosition position);

        public abstract bool OnlyHolesClosed();
    }
}