namespace KataPotter.Core.BookSetCostCalculators
{
    public class EmptyBookSetCostCalculator : IBookSetCostCalculator
    {
        public Money Calculate()
        {
            return new ZeroMoney();
        }
    }
}