namespace KataPotter.Core
{
    public class Money
    {
        readonly decimal _amount;

        public Money() { }
        public Money(decimal amount)
        {
            _amount = amount;
        }

        public Money Add(Money money)
        {
            if (money == null) return this;
            return money.Add(_amount);
        }

        public Money Add(decimal amount)
        {
            return new Money(_amount + amount);
        }

        public override string ToString()
        {
            return _amount.ToString("0");
        }
    }
}