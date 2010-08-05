using System.Collections;
using System.Collections.Generic;

namespace KataPotter.Core
{
    public class BookTitleCollection : IEnumerable<BookTitle>
    {
        readonly List<BookTitle> _bookTitles = new List<BookTitle>();

        public void Add(BookTitle title)
        {
            _bookTitles.Add(title);
        }

        //beware, modifies state
        public void Add(IEnumerable<BookTitle> titles)
        {
            _bookTitles.AddRange(titles);
        }

        public BookSet SelectBookSet()
        {
            //factory method
            switch (_bookTitles.Count)
            {
                case 0:
                    return new BookSet(BookSetType.Empty);
                case 1:
                    return new BookSet(BookSetType.OneBook);
                case 2:
                    return new BookSet(BookSetType.TwoBooks);
                case 3:
                    return new BookSet(BookSetType.ThreeBooks);
                case 4:
                    return new BookSet(BookSetType.FourBooks);
                case 5:
                    return new BookSet(BookSetType.FiveBooks);
            }

            return new BookSet(BookSetType.Empty);
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