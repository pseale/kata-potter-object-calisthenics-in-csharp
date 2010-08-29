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
            var result = _books.Where(x => x.Title == bookTitle);
            if (!result.Any()) return;
            _books.Remove(result.First());
        }

        public BookCollection Clone()
        {
            return new BookCollection(_books);
        }

        //TODO this violates Rule #3 (Wrap all primitives and strings). Unfortunately
        //I can't figure out a way to get rid of this (without cheating or breaking other rules).
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