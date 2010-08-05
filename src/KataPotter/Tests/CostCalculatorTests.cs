using KataPotter.Core;
using KataPotter.Extensions;
using NUnit.Framework;
using System.Collections.Generic;

namespace KataPotter.Tests
{
    [TestFixture]
    public class CostCalculatorTests
    {
        [Test]
        public void Zero_books_should_cost_nothing()
        {
            var books = new List<Book>();

            Assert.AreEqual(0m.FormatLikeMoney(), new CostCalculator().CalculateTotal(books).ToString());
        }

        [Test]
        public void One_book_should_give_no_discount()
        {
            var books = new List<Book>();
            books.Add(new Book(BookTitle.BookOne));

            Assert.AreEqual(8m.FormatLikeMoney(), new CostCalculator().CalculateTotal(books).ToString());
        }

        [Test]
        public void Two_same_books_should_give_no_discount()
        {
            var books = new List<Book>();
            books.Add(new Book(BookTitle.BookOne));
            books.Add(new Book(BookTitle.BookOne));

            Assert.AreEqual(16m.FormatLikeMoney(), new CostCalculator().CalculateTotal(books).ToString());
        }

        [Test]
        public void Two_different_books_should_give_a_five_percent_discount()
        {
            var books = new List<Book>();
            books.Add(new Book(BookTitle.BookOne));
            books.Add(new Book(BookTitle.BookTwo));

            Assert.AreEqual(((8m + 8m) * 0.95m).FormatLikeMoney(), new CostCalculator().CalculateTotal(books).ToString());
        }

        [Test]
        public void Three_same_books_should_give_no_discount()
        {
            var books = new List<Book>();
            books.Add(new Book(BookTitle.BookOne));
            books.Add(new Book(BookTitle.BookOne));
            books.Add(new Book(BookTitle.BookOne));

            Assert.AreEqual((8m + 8m + 8m).FormatLikeMoney(), new CostCalculator().CalculateTotal(books).ToString());
        }

        [Test]
        public void Three_different_books_should_give_a_ten_percent_discount()
        {
            var books = new List<Book>();
            books.Add(new Book(BookTitle.BookOne));
            books.Add(new Book(BookTitle.BookTwo));
            books.Add(new Book(BookTitle.BookThree));

            Assert.AreEqual(((8m + 8m + 8m) * 0.9m).FormatLikeMoney(), new CostCalculator().CalculateTotal(books).ToString());
        }

        [Test]
        public void Four_different_books_should_give_a_twenty_percent_discount()
        {
            var books = new List<Book>();
            books.Add(new Book(BookTitle.BookOne));
            books.Add(new Book(BookTitle.BookTwo));
            books.Add(new Book(BookTitle.BookThree));
            books.Add(new Book(BookTitle.BookFour));

            Assert.AreEqual(((8m + 8m + 8m + 8m) * 0.8m).FormatLikeMoney(), new CostCalculator().CalculateTotal(books).ToString());
        }

        [Test]
        public void Five_different_books_should_give_a_twenty_five_percent_discount()
        {
            var books = new List<Book>();
            books.Add(new Book(BookTitle.BookOne));
            books.Add(new Book(BookTitle.BookTwo));
            books.Add(new Book(BookTitle.BookThree));
            books.Add(new Book(BookTitle.BookFour));
            books.Add(new Book(BookTitle.BookFive));

            Assert.AreEqual(((8m + 8m + 8m + 8m + 8m) * 0.75m).FormatLikeMoney(), new CostCalculator().CalculateTotal(books).ToString());
        }

        [Test]
        public void Two_same_books_and_one_other_book_should_discount_only_the_two_discountedbooks()
        {
            var books = new List<Book>();
            books.Add(new Book(BookTitle.BookOne));
            books.Add(new Book(BookTitle.BookOne));
            books.Add(new Book(BookTitle.BookTwo));

            Assert.AreEqual((16m * .95m + 8m).FormatLikeMoney(), new CostCalculator().CalculateTotal(books).ToString());
        }

        [Test]
        public void Two_sets_of_four_different_books_should_give_twenty_percent_discount_to_all()
        {
            var books = new List<Book>();
            books.Add(new Book(BookTitle.BookOne));
            books.Add(new Book(BookTitle.BookTwo));
            books.Add(new Book(BookTitle.BookThree));
            books.Add(new Book(BookTitle.BookFour));

            books.Add(new Book(BookTitle.BookTwo));
            books.Add(new Book(BookTitle.BookThree));
            books.Add(new Book(BookTitle.BookFour));
            books.Add(new Book(BookTitle.BookFive));

            Assert.AreEqual(((8m * 8) * 0.80m).FormatLikeMoney(), new CostCalculator().CalculateTotal(books).ToString());
        }
    }
}