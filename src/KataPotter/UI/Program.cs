using System;
using System.Collections.Generic;
using System.Linq;
using KataPotter.Core;

namespace KataPotter.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-=-=-=-=-=- KATA POTTER -=-=-=-=-=-");
            Console.WriteLine("Discounted cost: $" + GetTotalFor(GetBooksFromInput()));
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        private static IEnumerable<int> GetBooksFromInput()
        {
            var result = TryGetBooksFromString(ReadFromInput());
            if (result == null || result.Count() == 0) return GetBooksFromInput();
            return result;
        }

        private static string GetTotalFor(IEnumerable<int> books)
        {
            return CostCalculator.CalculateTotal(books).ToString("0.00");
        }

        //lazy; return empty collection if we failed to parse the inputted book list
        private static IEnumerable<int> TryGetBooksFromString(string booksString)
        {
            var books = booksString.Split(',');
            if (books.Length == 0) return new int[0];
            int parseResult;
            var areAllBooksParseableAsIntegers = books.Select(x => Int32.TryParse(x, out parseResult)).All(x => x == true);
            if (!areAllBooksParseableAsIntegers) return new int[0];

            var bookNumbers = books.Select(x => Int32.Parse(x));
            if (!bookNumbers.All(x => 1 <= x && x <= 5)) return new int[0];

            return bookNumbers;
        }

        private static string ReadFromInput()
        {
            Console.Clear();
            Console.WriteLine("Enter the entire contents of your shopping cart, separating each book ");
            Console.WriteLine("with a comma. Books are numbered between 1 and 5.");
            Console.WriteLine("E.g., your cart may look like '1,2,3,1,2,1,5,4'.");
            Console.Write("Please enter your books now: ");
            var result = Console.ReadLine();
            if (string.IsNullOrEmpty(result)) return ReadFromInput();
            return result.Trim();
        }
    }
}
