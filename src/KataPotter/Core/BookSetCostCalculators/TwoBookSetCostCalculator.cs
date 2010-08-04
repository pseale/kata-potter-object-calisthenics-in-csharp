namespace KataPotter.Core.BookSetCostCalculators
{
    public class TwoBookSetCostCalculator : IBookSetCostCalculator
    {
        public Money Calculate()
        {
            return new Money(16m * 0.95m);
        }
    }
}