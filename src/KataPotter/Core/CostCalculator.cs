namespace KataPotter.Core
{
    public class CostCalculator
    {
        readonly BookCollection _books = new BookCollection();

        public void Add(Book book)
        {
            _books.Add(book);
        }

        public Money CalculateTotal()
        {
            return CalculateTotalRecursive(_books.RemoveSet());
        }

        private Money CalculateTotalRecursive(RemoveSetResult result)
        {
            if (result.IsEmpty()) return result.AddCost(new ZeroMoney());
            return result.AddCost(CalculateTotalRecursive(result.RemoveSet()));
        }
    }
}