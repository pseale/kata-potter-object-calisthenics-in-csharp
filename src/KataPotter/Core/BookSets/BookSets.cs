using KataPotter.Core.Calculations;

namespace KataPotter.Core.BookSets
{
    public class EmptyBookSet : IBookSet
    {
        public Money Calculate() { return new ZeroMoney(); }
    }

    public class OneBookSet : IBookSet
    {
        public Money Calculate() { return new Money(8m * 1.00m); }
    }

    public class TwoBookSet : IBookSet
    {
        public Money Calculate() { return new Money(16m * 0.95m); }
    }

    public class ThreeBookSet : IBookSet
    {
        public Money Calculate() { return new Money(24m * 0.90m); }
    }

    public class FourBookSet : IBookSet
    {
        public Money Calculate() { return new Money(32m * 0.80m); }
    }

    public class FiveBookSet : IBookSet
    {
        public Money Calculate() { return new Money(40m * 0.75m); }
    }
}