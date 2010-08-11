using KataPotter.Core.Books;
using KataPotter.Core.BookSets;

namespace KataPotter.Core.Calculations
{
    public class RemoveSetResult
    {
        readonly BookCollection _books;
        readonly IBookSet _bookSet;

        public RemoveSetResult(BookCollection books, IBookSet bookSet)
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
                .Calculate()
                .Add(money);
        }

        public RemoveSetResult RemoveSet()
        {
            return new BookSetDiscoverer().RemoveSet(_books);
        }

        public override string ToString()
        {
            return _books.ToString();
        }
    }
}