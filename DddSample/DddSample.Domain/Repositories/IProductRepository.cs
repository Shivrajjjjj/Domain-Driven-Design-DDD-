using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DddSample.Domain.Entities;

namespace DddSample.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(Guid id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task SaveChangesAsync();
    }
}
