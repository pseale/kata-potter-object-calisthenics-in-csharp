namespace KataPotter.Extensions
{
    public static class DecimalExtensions
    {
        //for tests
        public static string FormatLikeMoney(this decimal amount)
        {
            return amount.ToString("0");
        }
    }
}