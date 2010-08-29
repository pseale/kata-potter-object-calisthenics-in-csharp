using System.Collections.Generic;
using KataPotter.Core.Books;
using KataPotter.Core.BookSets;

namespace KataPotter.Core.Calculations
{
    public class CostCalculator
    {
        public Money CalculateTotal(IEnumerable<Book> books)
        {
            return 
                CalculateRecursive(
                    new BookSetDiscoverer()
                    .RemoveSet(new BookCollection(books)));
        }

        private Money CalculateRecursive(RemoveSetResult result)
        {
            if (result.IsEmpty()) 
                return result.AddCost(new ZeroMoney());
            return result.AddCost(
                CalculateRecursive(
                    result.RemoveSet()));
        }
    }
}