namespace KataPotter.Core.BookSets
{
    public class BookSetFactory
    {
        public IBookSet Create(BookSetType bookSetType)
        {
            switch (bookSetType)
            {
                case BookSetType.Empty:
                    return new EmptyBookSet();
                case BookSetType.OneBook:
                    return new OneBookSet();
                case BookSetType.TwoBooks:
                    return new TwoBookSet();
                case BookSetType.ThreeBooks:
                    return new ThreeBookSet();
                case BookSetType.FourBooks:
                    return new FourBookSet();
                case BookSetType.FiveBooks:
                    return new FiveBookSet();
            }

            //required by compiler
            return new EmptyBookSet();
        }
    }
}