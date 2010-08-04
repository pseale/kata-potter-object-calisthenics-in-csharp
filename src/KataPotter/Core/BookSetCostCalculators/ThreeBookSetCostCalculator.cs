namespace KataPotter.Core.BookSetCostCalculators
{
    public class ThreeBookSetCostCalculator : IBookSetCostCalculator
    {
        public Money Calculate()
        {
            return new Money(24m * 0.90m);
        }
    }
}