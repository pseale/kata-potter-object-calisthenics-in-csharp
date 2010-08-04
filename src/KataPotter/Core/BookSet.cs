using KataPotter.Core.BookSetCostCalculators;

namespace KataPotter.Core
{
    public class BookSet
    {
        BookSetType _bookSetType;

        public BookSet(BookSetType bookSetType)
        {
            _bookSetType = bookSetType;
        }

        public Money CalculatePrice()
        {
            return SelectFor(_bookSetType).Calculate();
        }

        IBookSetCostCalculator SelectFor(BookSetType bookSetType)
        {
            switch (bookSetType)
            {
                case BookSetType.Empty:
                    return new EmptyBookSetCostCalculator();
                case BookSetType.OneBook:
                    return new OneBookSetCostCalculator();
                case BookSetType.TwoBooks:
                    return new TwoBookSetCostCalculator();
                case BookSetType.ThreeBooks:
                    return new ThreeBookSetCostCalculator();
                case BookSetType.FourBooks:
                    return new FourBookSetCostCalculator();
                case BookSetType.FiveBooks:
                    return new FiveBookSetCostCalculator();
            }

            //required by compiler
            return new EmptyBookSetCostCalculator();
        }
    }
}