namespace KataPotter.Core
{
    public class RemoveSetResult
    {
        readonly BookCollection _books;
        readonly BookSet _bookSet;

        public RemoveSetResult(BookCollection books, BookSet bookSet)
        {
            _books = books;
            _bookSet = bookSet;
        }

        public bool IsEmpty()
        {
            return _books.IsEmpty();
        }

        public Money AddCost(Money money)
        {
            return _bookSet
                .CalculatePrice()
                .Add(money);
        }

        public RemoveSetResult RemoveSet()
        {
            return _books.RemoveSet();
        }

        public override string ToString()
        {
            return _books.ToString();
        }
    }
}