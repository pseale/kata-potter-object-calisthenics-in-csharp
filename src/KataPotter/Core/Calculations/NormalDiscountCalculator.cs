using System.Linq;
using KataPotter.Core.Books;

namespace KataPotter.Core.Calculations
{
    public class NormalDiscountCalculator
    {
        public BookTitleCollection GetBooks(BookCollection bookCollection)
        {
            var titles = bookCollection
                .GroupBy(x => x.Title)
                .Select(x => x.Key);
            return new BookTitleCollection(titles);
        }
    }
}