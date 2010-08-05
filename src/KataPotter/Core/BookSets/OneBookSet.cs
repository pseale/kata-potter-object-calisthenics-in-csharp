using KataPotter.Core.Calculations;

namespace KataPotter.Core.BookSets
{
    public class OneBookSet : IBookSet
    {
        public Money Calculate()
        {
            return new Money(8m * 1.00m);
        }
    }
}