using System.Collections.Generic;
using System.Linq;
using KataPotter.Core.Books;

namespace KataPotter.Core.Calculations
{
    /// <summary>
    /// This class is scary. It's built on the premise that there is one special case scenario,
    /// wherein (pay attention) 
    /// two four-book discounts: 2 * ( 4 * 8 * 0.80) = $51.20 is cheaper than
    /// a five-book discount and a three-book discount: (5 * 8 * 0.75) + (3 * 8 * 0.90) = $51.60
    /// 
    /// Using the "normal" discount strategy, it would behoove us to find the largest book set possible, and
    /// apply that discount. UNFORTUNATELY, in the weird scenario above, choosing the largest book set first
    /// would leave us with a smaller discount. SO. So, we must look ahead and figure out if we are left with
    /// two four-book discounts.
    /// 
    /// I've achieved this "looking ahead" functionality via some very unfortunate LINQ grouping. I 
    /// have attempted to clean it up, but the alternative to all this ugly LINQ is even uglier procedural-style code.
    /// </summary>
    public class SpecialDiscountCalculator
    {
        //should be private, but made public for tests
        public bool WorksFor(BookCollection bookCollection)
        {
            if (bookCollection.IsEmpty()) return false;
            //e.g. a book collection fitting this profile: 1;2;3;3;4;4;5;5
            //when grouped by GroupBooks, we would have two groups:
            // first group: 1-book-per-title (2 items: (1) ; (2))
            // second group: 2-books-per-title (3 items: (3;3) ; (4;4) ; (5;5))
            var bookSets = GroupBooks(bookCollection);
 
            bool exactlyTwoQuantitiesOfBooksRemain = bookSets.Count() == 2;
            bool theSmallerGroupingContainsBooksSpanningTwoTitles = bookSets.First().Count() == 2;
            bool theSmallerGroupingContainsOneBookPerTitle = bookSets.First().Key == 1;
            bool theLargerGroupingContainsBooksSpanningThreeTitles = bookSets.Last().Count() == 3;
            bool theLargerGroupingContainsTwoBooksPerTitle = bookSets.Last().Key == 2;

            return exactlyTwoQuantitiesOfBooksRemain
                && theSmallerGroupingContainsBooksSpanningTwoTitles
                && theSmallerGroupingContainsOneBookPerTitle
                && theLargerGroupingContainsBooksSpanningThreeTitles
                && theLargerGroupingContainsTwoBooksPerTitle;
        }

        public BookTitleCollection GetBooks(BookCollection bookCollection)
        {
            var bookSets = GroupBooks(bookCollection);
            var oneBookFromEachDoubleStockedTitle = bookSets
                .Last()
                .Select(x => x.Key);

            var oneSingleStockedTitle = new[]
                                 {
                                     bookSets.First().First().Key
                                 };

            var titles = oneBookFromEachDoubleStockedTitle.Union(oneSingleStockedTitle);
            return new BookTitleCollection(titles);
        }

        private IEnumerable<IGrouping<int, IGrouping<BookTitle, Book>>> GroupBooks(BookCollection bookCollection)
        {
            return bookCollection
                .GroupBy(x => x.Accept(y=>y))
                .GroupBy(x => x.Count())
                .OrderBy(x => x.Key);
        }
    }
}