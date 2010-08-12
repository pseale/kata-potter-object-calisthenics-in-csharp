using KataPotter.Core.Books;
using KataPotter.Core.Calculations;
using NUnit.Framework;

namespace KataPotter.Tests
{
    [TestFixture]
    public class SpecialDiscountCalculatorTests
    {
        [Test]
        public void When_provided_with_books_that_make_up_two_fourbook_discount__should_indicate_it_qualifies_for_a_special_discount()
        {
            var bookCollection = new BookCollection(new[]
                                                        {
                                                            new Book(BookTitle.BookOne),
                                                            new Book(BookTitle.BookTwo),
                                                            new Book(BookTitle.BookThree),
                                                            new Book(BookTitle.BookFour),

                                                            new Book(BookTitle.BookTwo),
                                                            new Book(BookTitle.BookThree),
                                                            new Book(BookTitle.BookFour),
                                                            new Book(BookTitle.BookFive),
                                                        });

            Assert.IsTrue(new SpecialDiscountCalculator().WorksFor(bookCollection));
        }

        [Test]
        public void When_provided_with_any_other_combination_of_books__should_indicate_it_does_not_qualify_for_a_special_discount()
        {
            var bookCollection = new BookCollection(new[]
                                                        {
                                                            new Book(BookTitle.BookOne),
                                                            new Book(BookTitle.BookTwo),
                                                            new Book(BookTitle.BookThree),
                                                            new Book(BookTitle.BookFour),

                                                            new Book(BookTitle.BookThree),
                                                            new Book(BookTitle.BookFour),
                                                            new Book(BookTitle.BookFive),
                                                        });

            Assert.IsFalse(new SpecialDiscountCalculator().WorksFor(bookCollection));
        }
    }
}