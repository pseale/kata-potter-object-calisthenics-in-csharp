using System.Collections;
using System.Collections.Generic;

namespace KataPotter.Core.Books
{
    public class BookTitleCollection : IEnumerable<BookTitle>
    {
        readonly List<BookTitle> _bookTitles = new List<BookTitle>();

        public BookTitleCollection(IEnumerable<BookTitle> titles)
        {
            _bookTitles.AddRange(titles);
        }

        public IEnumerator<BookTitle> GetEnumerator()
        {
            return _bookTitles.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}