using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KataPotter.Core.Books
{
    public class BookCollection : IEnumerable<Book>
    {
        List<Book> _books = new List<Book>();

        public BookCollection(IEnumerable<Book> books)
        {
            _books.AddRange(books);
        }

        //beware, modifies state
        public void Remove(BookTitle bookTitle)
        {
            var result = _books.Where(x => x.Accept(y => y == bookTitle));
            if (!result.Any()) return;
            _books.Remove(result.First());
        }

        public BookCollection Clone()
        {
            return new BookCollection(_books);
        }

        public bool IsEmpty()
        {
            return _books.Count == 0;
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return _books.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join(
                ";",
                _books
                    .OrderBy(x => x.Accept(y=>y))
                    .Select(x => x.ToString())
                    .ToArray());
        }
    }
}