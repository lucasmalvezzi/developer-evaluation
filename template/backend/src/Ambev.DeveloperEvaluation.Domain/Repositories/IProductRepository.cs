using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;
public interface IProductRepository
{
    Task<IEnumerable<Product>> GetByIds(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
}
