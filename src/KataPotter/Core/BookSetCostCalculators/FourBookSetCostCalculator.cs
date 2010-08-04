namespace KataPotter.Core.BookSetCostCalculators
{
    public class FourBookSetCostCalculator : IBookSetCostCalculator
    {
        public Money Calculate()
        {
            return new Money(32m * 0.80m);
        }
    }
}