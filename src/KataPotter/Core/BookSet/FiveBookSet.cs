namespace KataPotter.Core.BookSet
{
    public class FiveBookSet : IBookSet
    {
        public Money Calculate()
        {
            return new Money(40m * 0.75m);
        }
    }
}