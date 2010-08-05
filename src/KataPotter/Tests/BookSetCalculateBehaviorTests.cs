using KataPotter.Core.BookSets;
using KataPotter.Extensions;
using NUnit.Framework;

namespace KataPotter.Tests
{
    [TestFixture]
    public class BookSetCalculateBehaviorTests
    {
        [Test]
        public void When_calculating_the_cost_for_0_books__should_be_a_zero_amount()
        {
            var bookSet = new BookSetFactory().Create(BookSetType.Empty);

            Assert.AreEqual(0m.FormatLikeMoney(), bookSet.Calculate().ToString());
        }

        [Test]
        public void When_calculating_the_discounted_cost_for_1_book__should_give_no_discount()
        {
            var bookSet = new BookSetFactory().Create(BookSetType.OneBook);

            Assert.AreEqual(8m.FormatLikeMoney(), bookSet.Calculate().ToString());
        }

        [Test]
        public void When_calculating_the_discounted_cost_for_2_books__should_charge_95_percent_of_original()
        {
            var bookSet = new BookSetFactory().Create(BookSetType.TwoBooks);

            Assert.AreEqual((16m * 0.95m).FormatLikeMoney(), bookSet.Calculate().ToString());
        }

        [Test]
        public void When_calculating_the_discounted_cost_for_3_books__should_charge_90_percent_of_original()
        {
            var bookSet = new BookSetFactory().Create(BookSetType.ThreeBooks);

            Assert.AreEqual((24m * 0.90m).FormatLikeMoney(), bookSet.Calculate().ToString());
        }

        [Test]
        public void When_calculating_the_discounted_cost_for_4_books__should_charge_80_percent_of_original()
        {
            var bookSet = new BookSetFactory().Create(BookSetType.FourBooks);

            Assert.AreEqual((32m * 0.80m).FormatLikeMoney(), bookSet.Calculate().ToString());
        }

        [Test]
        public void When_calculating_the_discounted_cost_for_5_books__should_charge_75_percent_of_original()
        {
            var bookSet = new BookSetFactory().Create(BookSetType.FiveBooks);

            Assert.AreEqual((40m * 0.75m).FormatLikeMoney(), bookSet.Calculate().ToString());
        }
    }
}