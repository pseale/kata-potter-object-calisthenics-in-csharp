using KataPotter.Core.Books;
using NUnit.Framework;

namespace KataPotter.Tests
{
    [TestFixture]
    public class BookCollectionRemoveSetBehaviorTests
    {
        [Test]
        public void When_a_book_collection_with_no_books_is_asked_to_RemoveSet__should_remain_empty()
        {
            var bookCollection = new BookCollection(new Book[0]);

            var result = bookCollection.RemoveSet();

            Assert.AreEqual("", result.ToString());
        }

        [Test]
        public void When_a_book_collection_with_one_book_is_asked_to_RemoveSet__should_remove_the_one_book()
        {
            var bookCollection = new BookCollection(new[]
                                                        {
                                                            new Book(BookTitle.BookOne)
                                                        });

            var result = bookCollection.RemoveSet();

            Assert.AreEqual("", result.ToString());
        }

        [Test]
        public void When_a_book_collection_with_two_same_books_is_asked_to_RemoveSet__should_remove_one_of_the_books()
        {
            var bookCollection = new BookCollection(new[]
                                                        {
                                                            new Book(BookTitle.BookOne),
                                                            new Book(BookTitle.BookOne)
                                                        });

            var result = bookCollection.RemoveSet();

            Assert.AreEqual("1", result.ToString());
        }
    }
}