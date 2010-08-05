using KataPotter.Core.Calculations;

namespace KataPotter.Core.BookSets
{
    public class EmptyBookSet : IBookSet
    {
        public Money Calculate()
        {
            return new ZeroMoney();
        }
    }
}