using KataPotter.Core.Books;
using KataPotter.Core.Calculations;
using NUnit.Framework;

namespace KataPotter.Tests
{
    [TestFixture]
    public class BookCollectionRemoveSetBehaviorTests
    {
        BookCollection bookCollection;

        [SetUp]
        public void SetUp()
        {
            bookCollection = new BookCollection();
        }

        [Test]
        public void When_a_book_collection_with_no_books_is_asked_to_RemoveSet__should_remain_empty()
        {
            var result = bookCollection.RemoveSet();

            Assert.AreEqual("", result.ToString());
        }

        [Test]
        public void When_a_book_collection_with_one_book_is_asked_to_RemoveSet__should_remove_the_one_book()
        {
            bookCollection.Add(new Book(BookTitle.BookOne));

            var result = bookCollection.RemoveSet();

            Assert.AreEqual("", result.ToString());
        }

        [Test]
        public void When_a_book_collection_with_two_same_books_is_asked_to_RemoveSet__should_remove_one_of_the_books()
        {
            bookCollection.Add(new Book(BookTitle.BookOne));
            bookCollection.Add(new Book(BookTitle.BookOne));

            var result = bookCollection.RemoveSet();

            Assert.AreEqual("1", result.ToString());
        }
    }
}