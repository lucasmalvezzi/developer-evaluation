using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;
 
    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        await _context.Sales.AddAsync(sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return await _context.Sales
            .Include(s => s.SaleItems)
            .ThenInclude(si => si.Product).Where(s => s.Id == sale.Id).FirstAsync(cancellationToken);
    }

    public async Task<Sale?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Sales
            .Include(s => s.SaleItems)
            .ThenInclude(si => si.Product).Where(s => s.Id == id).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var sale = await GetByIdAsync(id, cancellationToken);
        if (sale == null)
            return false;
        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
    public async Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        _context.Sales.Update(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return await _context.Sales
            .Include(s => s.SaleItems)
            .ThenInclude(si => si.Product).Where(s => s.Id == sale.Id).FirstAsync(cancellationToken);
    }

    public async Task<PaginatedEntity<Sale>> GetAllPaginatedAsync(Guid? customerId, string? branch, bool? isCancelled, int _page, int _pageSize, CancellationToken cancellationToken = default)
    {
        var query = _context.Sales
            .Include(s => s.SaleItems)
            .ThenInclude(si => si.Product)
            .AsQueryable();

        if (customerId.HasValue)
            query = query.Where(s => s.CustomerId == customerId.Value);

        if (!string.IsNullOrEmpty(branch))
            query = query.Where(s => s.Branch == branch);
        if (isCancelled.HasValue)
            query = query.Where(s => s.IsCancelled == isCancelled.Value);

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .OrderByDescending(s => s.SaleDate)
            .Skip((_page - 1) * _pageSize)
            .Take(_pageSize)
            .ToListAsync(cancellationToken);

        return new PaginatedEntity<Sale>
            {
            Items = items,
            TotalCount = totalCount,
            TotalPages = (int)Math.Ceiling(totalCount / (double)_pageSize),
            CurrentPage = _page
        };


    }
}
