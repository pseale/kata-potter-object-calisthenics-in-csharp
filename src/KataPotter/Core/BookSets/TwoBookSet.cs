using KataPotter.Core.Calculations;

namespace KataPotter.Core.BookSets
{
    public class TwoBookSet : IBookSet
    {
        public Money Calculate()
        {
            return new Money(16m * 0.95m);
        }
    }
}