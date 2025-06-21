using Ambev.DeveloperEvaluation.Application.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;
public record ListSaleCommand : IRequest<PaginatedResult<ListSaleResult>>
{
    public Guid? CustomerId { get; set; } = null;
    public string? Branch { get; set; } = null;
    public bool? IsCancelled { get; set; } = null;
    public int _page { get; set; } = 1;
    public int _pageSize { get; set; } = 10;
}
