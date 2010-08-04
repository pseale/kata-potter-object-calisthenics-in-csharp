using KataPotter.Core;
using KataPotter.Extensions;
using NUnit.Framework;

namespace KataPotter.Tests
{
    [TestFixture]
    public class CostCalculatorTests
    {
        CostCalculator _costCalculator;

        [SetUp]
        public void Setup()
        {
            _costCalculator = new CostCalculator();
        }

        [Test]
        public void Zero_books_should_cost_nothing()
        {
            Assert.AreEqual(0m.FormatLikeMoney(), _costCalculator.CalculateTotal().ToString());
        }

        [Test]
        public void One_book_should_give_no_discount()
        {
            _costCalculator.Add(new Book(BookTitle.BookOne));

            Assert.AreEqual(8m.FormatLikeMoney(), _costCalculator.CalculateTotal().ToString());
        }

        [Test]
        public void Two_same_books_should_give_no_discount()
        {
            _costCalculator.Add(new Book(BookTitle.BookOne));
            _costCalculator.Add(new Book(BookTitle.BookOne));

            Assert.AreEqual(16m.FormatLikeMoney(), _costCalculator.CalculateTotal().ToString());
        }

        [Test]
        public void Two_different_books_should_give_a_five_percent_discount()
        {
            _costCalculator.Add(new Book(BookTitle.BookOne));
            _costCalculator.Add(new Book(BookTitle.BookTwo));

            Assert.AreEqual(((8m + 8m) * 0.95m).FormatLikeMoney(), _costCalculator.CalculateTotal().ToString());
        }

        [Test]
        public void Three_same_books_should_give_no_discount()
        {
            _costCalculator.Add(new Book(BookTitle.BookOne));
            _costCalculator.Add(new Book(BookTitle.BookOne));
            _costCalculator.Add(new Book(BookTitle.BookOne));

            Assert.AreEqual((8m + 8m + 8m).FormatLikeMoney(), _costCalculator.CalculateTotal().ToString());
        }

        [Test]
        public void Three_different_books_should_give_a_ten_percent_discount()
        {
            _costCalculator.Add(new Book(BookTitle.BookOne));
            _costCalculator.Add(new Book(BookTitle.BookTwo));
            _costCalculator.Add(new Book(BookTitle.BookThree));

            Assert.AreEqual(((8m + 8m + 8m) * 0.9m).FormatLikeMoney(), _costCalculator.CalculateTotal().ToString());
        }

        [Test]
        public void Four_different_books_should_give_a_twenty_percent_discount()
        {
            _costCalculator.Add(new Book(BookTitle.BookOne));
            _costCalculator.Add(new Book(BookTitle.BookTwo));
            _costCalculator.Add(new Book(BookTitle.BookThree));
            _costCalculator.Add(new Book(BookTitle.BookFour));

            Assert.AreEqual(((8m + 8m + 8m + 8m) * 0.8m).FormatLikeMoney(), _costCalculator.CalculateTotal().ToString());
        }

        [Test]
        public void Five_different_books_should_give_a_twenty_five_percent_discount()
        {
            _costCalculator.Add(new Book(BookTitle.BookOne));
            _costCalculator.Add(new Book(BookTitle.BookTwo));
            _costCalculator.Add(new Book(BookTitle.BookThree));
            _costCalculator.Add(new Book(BookTitle.BookFour));
            _costCalculator.Add(new Book(BookTitle.BookFive));

            Assert.AreEqual(((8m + 8m + 8m + 8m + 8m) * 0.75m).FormatLikeMoney(), _costCalculator.CalculateTotal().ToString());
        }

        [Test]
        public void Two_same_books_and_one_other_book_should_discount_only_the_two_discounted_books()
        {
            _costCalculator.Add(new Book(BookTitle.BookOne));
            _costCalculator.Add(new Book(BookTitle.BookOne));
            _costCalculator.Add(new Book(BookTitle.BookTwo));

            Assert.AreEqual((16m * .95m + 8m).FormatLikeMoney(), _costCalculator.CalculateTotal().ToString());
        }

        [Test]
        public void Two_sets_of_four_different_books_should_give_twenty_percent_discount_to_all()
        {
            _costCalculator.Add(new Book(BookTitle.BookOne));
            _costCalculator.Add(new Book(BookTitle.BookTwo));
            _costCalculator.Add(new Book(BookTitle.BookThree));
            _costCalculator.Add(new Book(BookTitle.BookFour));

            _costCalculator.Add(new Book(BookTitle.BookTwo));
            _costCalculator.Add(new Book(BookTitle.BookThree));
            _costCalculator.Add(new Book(BookTitle.BookFour));
            _costCalculator.Add(new Book(BookTitle.BookFive));

            Assert.AreEqual(((8m * 8) * 0.80m).FormatLikeMoney(), _costCalculator.CalculateTotal().ToString());
        }
    }
}