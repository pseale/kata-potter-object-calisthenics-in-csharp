using System.Collections;
using System.Collections.Generic;
using System.Linq;
using KataPotter.Core.BookSets;
using KataPotter.Core.Calculations;
using KataPotter.Extensions;

namespace KataPotter.Core.Books
{
    public class BookCollection : IEnumerable<Book>
    {
        List<Book> _books = new List<Book>();

        public BookCollection(IEnumerable<Book> books)
        {
            _books.AddRange(books);
        }

        public RemoveSetResult RemoveSet()
        {
            var books = Clone();
            var uniqueBookTitles = books.GetOptimumBookTitlesSet();
            uniqueBookTitles.Each(books.Remove);
            return new RemoveSetResult(books, new BookSetFactory().Create(uniqueBookTitles));
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

        public BookTitleCollection GetOptimumBookTitlesSet()
        {
            if (QualifiesForSpecialDiscount()) return BuildSpecialDiscountBookSet();
            return BuildLargestBookSetPossible();
        }

        private BookTitleCollection BuildSpecialDiscountBookSet()
        {
            var collection = new BookTitleCollection();
            var bookSets = GroupBooksByNumberOfBooksPerTitle();
            collection.Add(bookSets.Last().Select(x=>x.Key));
            collection.Add(bookSets.First().First().Key);
            return collection;
        }

        //should be private, but made public for tests
        public bool QualifiesForSpecialDiscount()
        {
            var bookSets = GroupBooksByNumberOfBooksPerTitle();
            return
                bookSets.Count() == 2
                && bookSets.First().Count() == 2
                && bookSets.First().Key == 1
                && bookSets.Last().Count() == 3
                && bookSets.Last().Key == 2;
        }

        private IOrderedEnumerable<IGrouping<int, IGrouping<BookTitle, Book>>> GroupBooksByNumberOfBooksPerTitle()
        {
            return _books.GroupBy(x => x.Title).GroupBy(x => x.Count()).OrderBy(x=>x.Key);
        }

        private BookTitleCollection BuildLargestBookSetPossible()
        {
            var bookTitlesCollection = new BookTitleCollection();
            _books
                .GroupBy(x => x.Title)
                .Select(x => x.Key)
                .Each(bookTitlesCollection.Add);
            return bookTitlesCollection;
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