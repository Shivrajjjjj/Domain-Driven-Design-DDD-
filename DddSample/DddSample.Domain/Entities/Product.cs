using System;
using System.Collections.Generic;

namespace DddSample.Domain.Entities
{
    public class Product
    {
        private readonly List<ProductPrice> _prices = new();

        public Guid Id { get; private set; }
        public string Sku { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public DateTime CreatedAtUtc { get; private set; }

        // Navigation property
        public IReadOnlyCollection<ProductPrice> Prices => _prices.AsReadOnly();

        private Product() { } // EF Core constructor

        public Product(Guid id, string sku, string name)
        {
            Id = id;
            Sku = sku ?? throw new ArgumentNullException(nameof(sku));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            CreatedAtUtc = DateTime.UtcNow;
        }


        public void AddPrice(string currency, decimal amount)
        {
            var price = new ProductPrice(Id, currency, amount);
            _prices.Add(price);
        }
    }
}
