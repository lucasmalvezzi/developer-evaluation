using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DefaultContext _context;
    public ProductRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetByIds(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
    {
        return await _context.Products.Where(p=> ids.Contains(p.Id)).ToListAsync();
    }


}
