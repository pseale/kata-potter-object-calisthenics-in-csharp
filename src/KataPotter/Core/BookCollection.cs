using System.Collections.Generic;
using System.Linq;
using KataPotter.Extensions;
using KataPotter.Tests;

namespace KataPotter.Core
{
    public class BookCollection
    {
        List<Book> _books = new List<Book>();

        public RemoveSetResult RemoveSet()
        {
            var books = Clone();
            var uniqueBookTitles = books.GetOptimumBookTitlesSet();
            uniqueBookTitles.RemoveFrom(books);
            return new RemoveSetResult(books, uniqueBookTitles.SelectBookSet());
        }

        //beware, modifies state
        public void Add(Book book)
        {
            _books.Add(book);
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

        public BookTitlesCollection GetOptimumBookTitlesSet()
        {
            if (QualifiesForSpecialDiscount()) return BuildSpecialDiscountBookSet();
            return BuildLargestBookSetPossible();
        }

        private BookTitlesCollection BuildSpecialDiscountBookSet()
        {
            var collection = new BookTitlesCollection();
            var bookSets = GroupBooksByNumberOfBooksPerTitle();
            bookSets.Last().Each(x => collection.Add(x.Key));
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

        private BookTitlesCollection BuildLargestBookSetPossible()
        {
            var bookTitlesCollection = new BookTitlesCollection();
            _books
                .GroupBy(x => x.Title)
                .Select(x => x.Key)
                .Each(bookTitlesCollection.Add);
            return bookTitlesCollection;
        }

        //should be private, but is public for unit tests
        public BookCollection Clone()
        {
            var clone = new BookCollection();
            _books.Each(clone.Add);
            return clone;
        }

        public bool IsEmpty()
        {
            return _books.Count == 0;
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