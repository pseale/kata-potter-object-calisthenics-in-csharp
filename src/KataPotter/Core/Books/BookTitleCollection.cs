using System.Collections;
using System.Collections.Generic;

namespace KataPotter.Core.Books
{
    public class BookTitleCollection : IEnumerable<BookTitle>
    {
        readonly List<BookTitle> _bookTitles = new List<BookTitle>();

        //beware, modifies state
        public void Add(BookTitle title)
        {
            _bookTitles.Add(title);
        }

        //beware, modifies state
        public void Add(IEnumerable<BookTitle> titles)
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