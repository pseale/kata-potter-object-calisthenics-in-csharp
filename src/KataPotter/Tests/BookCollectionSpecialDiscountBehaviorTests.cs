using KataPotter.Core.Books;
using NUnit.Framework;

namespace KataPotter.Tests
{
    [TestFixture]
    public class BookCollectionSpecialDiscountBehaviorTests
    {
        [Test]
        public void When_provided_with_books_that_make_up_two_fourbook_discount__should_indicate_it_qualifies_for_a_special_discount()
        {
            var bookCollection = new BookCollection();
            bookCollection.Add(new Book(BookTitle.BookOne));
            bookCollection.Add(new Book(BookTitle.BookTwo));
            bookCollection.Add(new Book(BookTitle.BookThree));
            bookCollection.Add(new Book(BookTitle.BookFour));

            bookCollection.Add(new Book(BookTitle.BookTwo));
            bookCollection.Add(new Book(BookTitle.BookThree));
            bookCollection.Add(new Book(BookTitle.BookFour));
            bookCollection.Add(new Book(BookTitle.BookFive));

            Assert.IsTrue(bookCollection.QualifiesForSpecialDiscount());
        }

        [Test]
        public void When_provided_with_any_other_combination_of_books__should_indicate_it_does_not_qualify_for_a_special_discount()
        {
            var bookCollection = new BookCollection();
            bookCollection.Add(new Book(BookTitle.BookOne));
            bookCollection.Add(new Book(BookTitle.BookTwo));
            bookCollection.Add(new Book(BookTitle.BookThree));
            bookCollection.Add(new Book(BookTitle.BookFour));

            bookCollection.Add(new Book(BookTitle.BookThree));
            bookCollection.Add(new Book(BookTitle.BookFour));
            bookCollection.Add(new Book(BookTitle.BookFive));

            Assert.IsFalse(bookCollection.QualifiesForSpecialDiscount());
        }
    }
}