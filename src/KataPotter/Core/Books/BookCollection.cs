using System.Collections;
using System.Collections.Generic;
using System.Linq;
using KataPotter.Core.Calculations;

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
            var result = _books.Where(x => x.Title == bookTitle);
            if (!result.Any()) return;
            Remove(result.First());
        }

        //beware, modifies state
        private void Remove(Book book)
        {
            _books.Remove(book);
        }

        //should be private, but is public for unit tests
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
                    .OrderBy(x => x.Title)
                    .Select(x => x.ToString())
                    .ToArray());
        }
    }
}