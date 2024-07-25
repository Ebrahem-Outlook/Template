using Application.Abstractions.Data;
using Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class ProductRepository(IDbContext dbContext) : IProductRepository
{
    public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        await dbContext.Set<Product>().AddAsync(product, cancellationToken);
    }

    public void Update(Product product)
    {
        dbContext.Set<Product>().Update(product);
    }

    public void Delete(Product product)
    {
        dbContext.Set<Product>().Remove(product);
    }

    public async Task<List<Product>?> GetAllAsync(CancellationToken cancellationToken)
    {
        return await dbContext.Set<Product>()
                              .AsNoTracking()
                              .ToListAsync(cancellationToken);
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<Product>()
                              .AsNoTracking()
                              .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<List<Product>?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<Product>()
                              .AsNoTracking()
                              .Where(p => p.Name == name)
                              .ToListAsync(cancellationToken);
    }
}
