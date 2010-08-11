using KataPotter.Core.Books;
using NUnit.Framework;

namespace KataPotter.Tests
{
    [TestFixture]
    public class BookCollectionTests
    {
        [Test]
        public void When_a_book_collection_is_empty__should_show_itself_as_empty()
        {
            var bookCollection = new BookCollection(new Book[0]);

            Assert.AreEqual("", bookCollection.ToString());
        }

        [Test]
        public void When_a_book_collection_adds_a_book__should_show_as_having_that_book()
        {
            var bookCollection = new BookCollection(new[]
                                                        {
                                                            new Book(BookTitle.BookOne)
                                                        });

            Assert.AreEqual("1", bookCollection.ToString());
        }

        [Test]
        public void When_a_book_collection_adds_books__should_show_them_separated_by_semicolons()
        {
            var bookCollection = new BookCollection(new[]
                                                        {
                                                            new Book(BookTitle.BookOne),
                                                            new Book(BookTitle.BookTwo),
                                                            new Book(BookTitle.BookThree),
                                                        });

            Assert.AreEqual("1;2;3", bookCollection.ToString());
        }

        [Test]
        public void When_a_book_collection_adds_books_out_of_proper_order__should_show_the_books_in_order_regardless()
        {
            var bookCollection = new BookCollection(new[]
                                                        {
                                                            new Book(BookTitle.BookTwo),
                                                            new Book(BookTitle.BookOne),
                                                            new Book(BookTitle.BookThree),
                                                            new Book(BookTitle.BookOne), 
                                                        });

            Assert.AreEqual("1;1;2;3", bookCollection.ToString());
        }
    }
}