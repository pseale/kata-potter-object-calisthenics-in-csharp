using KataPotter.Core.Calculations;

namespace KataPotter.Core.BookSets
{
    public class FourBookSet : IBookSet
    {
        public Money Calculate()
        {
            return new Money(32m * 0.80m);
        }
    }
}