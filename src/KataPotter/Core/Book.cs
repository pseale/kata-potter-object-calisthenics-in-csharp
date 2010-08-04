namespace KataPotter.Core
{
    public class Book
    {
        readonly BookTitle _bookTitle;

        public Book(BookTitle bookTitle)
        {
            _bookTitle = bookTitle;
        }

        public BookTitle Title { get { return _bookTitle; } }

        public override string ToString()
        {
            return ((int)_bookTitle).ToString();
        }
    }
}