using KataPotter.Core;
using NUnit.Framework;
using System.Collections.Generic;

namespace KataPotter.Tests
{
    [TestFixture]
    public class AcceptanceTests
    {
        [Test]
        public void No_books__should_cost_nothing()
        {
            var books = new List<int>();

            Assert.AreEqual(0m, CostCalculator.CalculateTotal(books));
        }

        [Test]
        public void One_book__should_give_no_discount()
        {
            var books = new List<int>();
            books.Add(1);

            Assert.AreEqual(8m, CostCalculator.CalculateTotal(books));
        }

        [Test]
        public void Two_same_books__should_give_no_discount()
        {
            var books = new List<int>();
            books.Add(1);
            books.Add(1);

            Assert.AreEqual(8m + 8m, CostCalculator.CalculateTotal(books));
        }

        [Test]
        public void Two_different_books__should_give_a_five_percent_discount()
        {
            var books = new List<int>();
            books.Add(1);
            books.Add(2);

            Assert.AreEqual(((8m + 8m) * 0.95m), CostCalculator.CalculateTotal(books));
        }

        [Test]
        public void Three_same_books__should_give_no_discount()
        {
            var books = new List<int>();
            books.Add(1);
            books.Add(1);
            books.Add(1);

            Assert.AreEqual((8m + 8m + 8m), CostCalculator.CalculateTotal(books));
        }

        [Test]
        public void Three_different_books__should_give_a_ten_percent_discount()
        {
            var books = new List<int>();
            books.Add(1);
            books.Add(2);
            books.Add(3);

            Assert.AreEqual(((8m + 8m + 8m) * 0.9m), CostCalculator.CalculateTotal(books));
        }

        [Test]
        public void Four_different_books__should_give_a_twenty_percent_discount()
        {
            var books = new List<int>();
            books.Add(1);
            books.Add(2);
            books.Add(3);
            books.Add(4);

            Assert.AreEqual(((8m + 8m + 8m + 8m) * 0.8m), CostCalculator.CalculateTotal(books));
        }

        [Test]
        public void Five_different_books__should_give_a_twenty_five_percent_discount()
        {
            var books = new List<int>();
            books.Add(1);
            books.Add(2);
            books.Add(3);
            books.Add(4);
            books.Add(5);

            Assert.AreEqual(((8m + 8m + 8m + 8m + 8m) * 0.75m), CostCalculator.CalculateTotal(books));
        }

        [Test]
        public void Two_same_books_and_one_other_book__should_discount_only_the_two_discounted_books()
        {
            var books = new List<int>();
            books.Add(1);
            books.Add(1);
            books.Add(2);

            Assert.AreEqual(((8m + 8m) * .95m + 8m), CostCalculator.CalculateTotal(books));
        }

        //this is a special case and requires changing the way the cost calculator works.
        [Test, Ignore]
        public void Two_sets_of_four_different_books__should_give_twenty_percent_discount_to_all()
        {
            var books = new List<int>();
            books.Add(1);
            books.Add(2);
            books.Add(3);
            books.Add(4);

            books.Add(2);
            books.Add(3);
            books.Add(4);
            books.Add(5);

            Assert.AreEqual(((8m * 8) * 0.80m), CostCalculator.CalculateTotal(books));
        }
    }
}