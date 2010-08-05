using System.Collections;
using System.Collections.Generic;
using KataPotter.Core.BookSet;

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

        public IBookSet SelectBookSet()
        {
            //factory method
            switch (_bookTitles.Count)
            {
                case 0:
                    return new EmptyBookSet();
                case 1:
                    return new OneBookSet();
                case 2:
                    return new TwoBookSet();
                case 3:
                    return new ThreeBookSet();
                case 4:
                    return new FourBookSet();
                case 5:
                    return new FiveBookSet();
            }

            return new EmptyBookSet();
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