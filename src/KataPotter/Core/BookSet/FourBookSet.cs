namespace KataPotter.Core.BookSet
{
    public class FourBookSet : IBookSet
    {
        public Money Calculate()
        {
            return new Money(32m * 0.80m);
        }
    }
}