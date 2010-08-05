namespace KataPotter.Core.BookSet
{
    public class OneBookSet : IBookSet
    {
        public Money Calculate()
        {
            return new Money(8m * 1.00m);
        }
    }
}