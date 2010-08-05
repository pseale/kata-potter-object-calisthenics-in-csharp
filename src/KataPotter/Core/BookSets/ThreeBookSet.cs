using KataPotter.Core.Calculations;

namespace KataPotter.Core.BookSets
{
    public class ThreeBookSet : IBookSet
    {
        public Money Calculate()
        {
            return new Money(24m * 0.90m);
        }
    }
}