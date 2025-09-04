using DddSample.Domain.Entities;
using DddSample.Domain.Repositories;
using DddSample.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DddSample.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetByIdAsync(Guid id) =>
            await _context.Products
                          .Include(p => p.Prices)
                          .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IEnumerable<Product>> GetAllAsync() =>
            await _context.Products
                          .Include(p => p.Prices)
                          .ToListAsync();

        public async Task AddAsync(Product product) =>
            await _context.Products.AddAsync(product);

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
