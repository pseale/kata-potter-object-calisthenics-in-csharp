using KataPotter.Core.Books;
using NUnit.Framework;

namespace KataPotter.Tests
{
    [TestFixture]
    public class BookCollectionCloneBehaviorTests
    {
        [Test]
        public void When_an_empty_book_collection_is_asked_to_clone__should_create_an_empty_clone()
        {
            var originalBookCollection = new BookCollection();
            var clonedBookCollection = originalBookCollection.Clone();

            Assert.AreEqual(originalBookCollection.ToString(), clonedBookCollection.ToString());
        }

        [Test]
        public void When_a_book_collection_is_asked_to_clone__should_create_a_copy_with_the_same_books()
        {
            var originalBookCollection = new BookCollection();
            originalBookCollection.Add(new Book(BookTitle.BookOne));

            var clonedBookCollection = originalBookCollection.Clone();

            Assert.AreEqual(originalBookCollection.ToString(), clonedBookCollection.ToString());
        }

        [Test]
        public void When_a_book_collection_is_asked_to_clone__should_not_allow_changes_in_original_to_affect_clone()
        {
            var originalBookCollection = new BookCollection();
            var clonedBookCollection = originalBookCollection.Clone();

            originalBookCollection.Add(new Book(BookTitle.BookOne));


            Assert.AreEqual("", clonedBookCollection.ToString());
            Assert.AreEqual("1", originalBookCollection.ToString());
        }
    }
}