using DddSample.Application.DTOs;

namespace DddSample.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(Guid id);
        Task AddAsync(ProductDto productDto);
    }
}
