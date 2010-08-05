using System.Collections.Generic;
using KataPotter.Core.Books;
using KataPotter.Extensions;

namespace KataPotter.Core.Calculations
{
    public class CostCalculator
    {
        public Money CalculateTotal(IEnumerable<Book> books)
        {
            var bookCollection = new BookCollection();
            books.Each(bookCollection.Add);
            return CalculateTotalRecursive(bookCollection.RemoveSet());
        }

        private Money CalculateTotalRecursive(RemoveSetResult result)
        {
            if (result.IsEmpty()) return result.AddCost(new ZeroMoney());
            return result.AddCost(CalculateTotalRecursive(result.RemoveSet()));
        }
    }
}