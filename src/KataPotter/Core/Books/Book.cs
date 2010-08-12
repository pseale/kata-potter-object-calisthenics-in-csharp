using System;

namespace KataPotter.Core.Books
{
    public class Book
    {
        readonly BookTitle _bookTitle;

        public Book(BookTitle bookTitle)
        {
            _bookTitle = bookTitle;
        }

        //This is allegedly a piece of the visitor pattern, and abides by the rules. I'm personally hesistant
        //to call it anything but cheating. Maybe I took too many shortcuts? Is using a generic
        //Func cheating? Probably. 
        //
        //Especially so when I only change out a "book.Title" call with "book.Accept(y=>y)"-- 
        //functionally identical and thus highly suspect.
        public T Accept<T>(Func<BookTitle, T> func)
        {
            return func(_bookTitle);
        }

        public override string ToString()
        {
            return ((int)_bookTitle).ToString();
        }
    }
}