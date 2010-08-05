using System.Linq;
using KataPotter.Core.Books;

namespace KataPotter.Core.BookSets
{
    public class BookSetFactory
    {
        public IBookSet Create(BookTitleCollection collection)
        {
            //factory method
            switch (collection.Count())
            {
                case 0:
                    return new EmptyBookSet();
                case 1:
                    return new OneBookSet();
                case 2:
                    return new TwoBookSet();
                case 3:
                    return new ThreeBookSet();
                case 4:
                    return new FourBookSet();
                case 5:
                    return new FiveBookSet();
            }

            return new EmptyBookSet();
        }
    }
}