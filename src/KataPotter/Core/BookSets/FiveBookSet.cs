using KataPotter.Core.Calculations;

namespace KataPotter.Core.BookSets
{
    public class FiveBookSet : IBookSet
    {
        public Money Calculate()
        {
            return new Money(40m * 0.75m);
        }
    }
}