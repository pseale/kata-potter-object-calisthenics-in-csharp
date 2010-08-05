namespace KataPotter.Core.BookSet
{
    public class ThreeBookSet : IBookSet
    {
        public Money Calculate()
        {
            return new Money(24m * 0.90m);
        }
    }
}