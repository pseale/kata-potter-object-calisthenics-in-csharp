using KataPotter.Core;
using NUnit.Framework;

namespace KataPotter.Tests
{
    [TestFixture]
    public class BookTests
    {
        [Test]
        public void When_displaying_a_book__should_show_the_book_title_as_a_number()
        {
            var book = new Book(BookTitle.BookOne);

            Assert.AreEqual("1", book.ToString());
        }
    }
}