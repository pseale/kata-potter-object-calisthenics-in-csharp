using System.Collections.Generic;
using KataPotter.Extensions;

namespace KataPotter.Core
{
    public class BookTitlesCollection
    {
        readonly List<BookTitle> _bookTitles = new List<BookTitle>();

        //beware, modifies state
        public void Add(BookTitle bookTitle)
        {
            _bookTitles.Add(bookTitle);
        }

        public void RemoveFrom(BookCollection books)
        {
            _bookTitles.Each(books.Remove);
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
    }
}