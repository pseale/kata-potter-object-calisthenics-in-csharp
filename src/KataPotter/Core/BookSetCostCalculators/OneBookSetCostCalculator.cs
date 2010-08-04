namespace KataPotter.Core.BookSetCostCalculators
{
    public class OneBookSetCostCalculator : IBookSetCostCalculator
    {
        public Money Calculate()
        {
            return new Money(8m * 1.00m);
        }
    }
}