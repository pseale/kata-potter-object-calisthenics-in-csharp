using System.Collections.Generic;
using System.Linq;
using KataPotter.Core.Books;

namespace KataPotter.Core.Calculations
{
    public class SpecialDiscountCalculator
    {
        //should be private, but made public for tests
        public bool Qualifies(BookCollection bookCollection)
        {
            var bookSets = GroupBooksByNumberOfBooksPerTitle(bookCollection);
            return bookSets.Count() == 2
                   && bookSets.First().Count() == 2
                   && bookSets.First().Key == 1
                   && bookSets.Last().Count() == 3
                   && bookSets.Last().Key == 2;
        }

        public BookTitleCollection GetBooks(BookCollection bookCollection)
        {
            var bookSets = GroupBooksByNumberOfBooksPerTitle(bookCollection);
            var titles = bookSets
                .Last()
                .Select(x => x.Key)
                .Union(new[]
                           {
                               bookSets.First().First().Key
                           });
            return new BookTitleCollection(titles);
        }

        private IEnumerable<IGrouping<int, IGrouping<BookTitle, Book>>> GroupBooksByNumberOfBooksPerTitle(BookCollection bookCollection)
        {
            return bookCollection
                .GroupBy(x => x.Title)
                .GroupBy(x => x.Count())
                .OrderBy(x => x.Key);
        }
    }
}