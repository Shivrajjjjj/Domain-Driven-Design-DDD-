using DddSample.Application.DTOs;
using DddSample.Application.Interfaces;
using DddSample.Application.Mapping;
using DddSample.Domain.Repositories;

namespace DddSample.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            return products.Select(p => p.ToDto()).ToList();
        }

        public async Task<ProductDto?> GetByIdAsync(Guid id)
        {
            var product = await _repository.GetByIdAsync(id);
            return product?.ToDto();
        }

        public async Task AddAsync(ProductDto dto)
        {
            var product = dto.ToEntity();
            await _repository.AddAsync(product);
            await _repository.SaveChangesAsync();
        }
    }
}
