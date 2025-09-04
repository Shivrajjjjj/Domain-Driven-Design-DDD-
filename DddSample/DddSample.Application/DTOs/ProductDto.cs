using System;

namespace DddSample.Application.DTOs
{
    public record ProductDto(Guid Id, string Sku, string Name, decimal Price, string Currency);
}
