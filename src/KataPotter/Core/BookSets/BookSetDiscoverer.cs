using KataPotter.Core.Books;
using KataPotter.Core.Calculations;
using KataPotter.Extensions;

namespace KataPotter.Core.BookSets
{
    public class BookSetDiscoverer
    {
        public RemoveSetResult RemoveSet(BookCollection bookCollection)
        {
            var books = bookCollection.Clone();
            var uniqueBookTitles = ChooseBooks(bookCollection);
            uniqueBookTitles.Each(books.Remove);
            return new RemoveSetResult(books, new BookSetFactory().Create(uniqueBookTitles));
        }

        private BookTitleCollection ChooseBooks(BookCollection bookCollection)
        {
            if (new SpecialDiscountCalculator().WorksFor(bookCollection)) return new SpecialDiscountCalculator().GetBooks(bookCollection);
            return new NormalDiscountCalculator().GetBooks(bookCollection);
        }
    }
}