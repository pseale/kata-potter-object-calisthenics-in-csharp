﻿using KataPotter.Core.BookSet;

namespace KataPotter.Core
{
    public class RemoveSetResult
    {
        readonly BookCollection _books;
        readonly IBookSet _bookSet;

        public RemoveSetResult(BookCollection books, IBookSet bookSet)
        {
            _books = books;
            _bookSet = bookSet;
        }

        public bool IsEmpty()
        {
            return _books.IsEmpty();
        }

        public Money AddCost(Money money)
        {
            return _bookSet
                .Calculate()
                .Add(money);
        }

        public RemoveSetResult RemoveSet()
        {
            return _books.RemoveSet();
        }

        public override string ToString()
        {
            return _books.ToString();
        }
    }
}