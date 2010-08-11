using KataPotter.Core.Calculations;
using NUnit.Framework;

namespace KataPotter.Tests
{
    [TestFixture]
    public class MoneyTests
    {
        [Test]
        public void When_adding_moneys__should_add_the_sum_of_their_amounts()
        {
            var money1 = new Money(1m);
            var money2 = new Money(4m);

            Assert.AreEqual("5.00", money1.Add(money2).ToString());
        }

        [Test]
        public void When_adding_a_null_value_to_money__should_treat_the_null_value_as_a_zero_value()
        {
            var money1 = new Money(1m);

            Assert.AreEqual("1.00", money1.Add(null).ToString());
        }
    }
}