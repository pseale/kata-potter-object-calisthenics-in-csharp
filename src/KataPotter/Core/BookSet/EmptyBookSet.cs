namespace KataPotter.Core.BookSet
{
    public class EmptyBookSet : IBookSet
    {
        public Money Calculate()
        {
            return new ZeroMoney();
        }
    }
}