using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace DddSample.Domain.Entities
{
    public class ProductPrice
    {
        public int Id { get; private set; }
        public Guid ProductId { get; private set; }
        public string Currency { get; private set; } = string.Empty;
        public decimal Amount { get; private set; }

        private ProductPrice() { } // EF Core constructor

        public ProductPrice(Guid productId, string currency, decimal amount)
        {
            ProductId = productId;
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
            Amount = amount;
        }

        public void UpdateAmount(decimal newAmount)
        {
            Amount = newAmount;
        }
    }
}
