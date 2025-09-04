namespace DddSample.Domain.ValueObjects
{
    public sealed class ProductPrice
    {
        public int Id { get; private set; }  // PK
        public Guid ProductId { get; private set; } // FK

        public string Currency { get; private set; } = null!;
        public decimal Amount { get; private set; }

        protected ProductPrice() { } // EF

        public ProductPrice(string currency, decimal amount)
        {
            if (string.IsNullOrWhiteSpace(currency))
                throw new ArgumentException("Currency is required", nameof(currency));

            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            Currency = currency.ToUpperInvariant();
            Amount = amount;
        }

        public void UpdateAmount(decimal newAmount)
        {
            if (newAmount < 0)
                throw new ArgumentOutOfRangeException(nameof(newAmount));

            Amount = newAmount;
        }
    }
}
