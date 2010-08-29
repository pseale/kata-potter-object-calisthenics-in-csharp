namespace KataPotter.Core.Calculations
{
    public class Money
    {
        readonly decimal _amount;

        public Money(decimal amount)
        {
            _amount = amount;
        }

        public Money Add(Money money)
        {
            //use compiler trick to access internal member of another object of the same class
            return new Money(money._amount + _amount);
        }

        public override string ToString()
        {
            return _amount.ToString("0.00");
        }
    }
}