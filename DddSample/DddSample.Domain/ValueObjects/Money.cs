namespace DddSample.Domain.ValueObjects
{
    // Simple Value Object for returning price
    public sealed class Money
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public Money(decimal amount, string currency)
        {
            if (string.IsNullOrWhiteSpace(currency))
                throw new ArgumentException("Currency is required", nameof(currency));

            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            Amount = amount;
            Currency = currency.ToUpperInvariant();
        }

        public override string ToString() => $"{Amount:0.00} {Currency}";
    }
}
