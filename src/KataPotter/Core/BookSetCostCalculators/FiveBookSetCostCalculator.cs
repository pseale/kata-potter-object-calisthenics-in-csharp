namespace KataPotter.Core.BookSetCostCalculators
{
    public class FiveBookSetCostCalculator : IBookSetCostCalculator
    {
        public Money Calculate()
        {
            return new Money(40m * 0.75m);
        }
    }
}