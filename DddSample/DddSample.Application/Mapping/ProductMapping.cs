using DddSample.Application.DTOs;
using DddSample.Domain.Entities; // ✅ Use Entities, not ValueObjects

namespace DddSample.Application.Mapping
{
    public static class ProductMapping
    {
        public static ProductDto ToDto(this Product product)
        {
            var latestPrice = product.Prices
                .OrderByDescending(p => p.Id)
                .FirstOrDefault();

            return new ProductDto(
                product.Id,
                product.Sku,
                product.Name,
                latestPrice?.Amount ?? 0,
                latestPrice?.Currency ?? "N/A"
            );
        }

        public static Product ToEntity(this ProductDto dto)
        {
            // Use dto properties
            var product = new Product(dto.Id, dto.Sku, dto.Name);

            if (dto.Price > 0)
            {
                product.AddPrice(dto.Currency, dto.Price);
            }

            return product;
        }

    }
}
