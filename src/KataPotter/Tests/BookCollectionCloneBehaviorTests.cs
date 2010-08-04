using KataPotter.Core;
using NUnit.Framework;

namespace KataPotter.Tests
{
    [TestFixture]
    public class BookCollectionCloneBehaviorTests
    {
        BookCollection originalBookCollection;
        
        [SetUp]
        public void SetUp()
        {
            originalBookCollection = new BookCollection();
        }

        [Test]
        public void When_an_empty_book_collection_is_asked_to_clone__should_create_an_empty_clone()
        {
            var clonedBookCollection = originalBookCollection.Clone();

            Assert.AreEqual(originalBookCollection.ToString(), clonedBookCollection.ToString());
        }

        [Test]
        public void When_a_book_collection_is_asked_to_clone__should_create_a_copy_with_the_same_books()
        {
            originalBookCollection.Add(new Book(BookTitle.BookOne));

            var clonedBookCollection = originalBookCollection.Clone();

            Assert.AreEqual(originalBookCollection.ToString(), clonedBookCollection.ToString());
        }

        [Test]
        public void When_a_book_collection_is_asked_to_clone__should_not_allow_changes_in_original_to_affect_clone()
        {
            var clonedBookCollection = originalBookCollection.Clone();

            originalBookCollection.Add(new Book(BookTitle.BookOne));


            Assert.AreEqual("", clonedBookCollection.ToString());
            Assert.AreEqual("1", originalBookCollection.ToString());
        }
    }
}