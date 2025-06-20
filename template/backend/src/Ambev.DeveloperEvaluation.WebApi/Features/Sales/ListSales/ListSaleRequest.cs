using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
public class ListSaleRequest
{
    [FromRoute]
    public Guid? CustomerId { get; set; } = null;
    [FromRoute]
    public string? Branch { get; set; } = null;
    [FromRoute]
    public bool? IsCancelled { get; set; } = null;
    [FromRoute]
    public int _page { get; set; } = 1;
    [FromRoute]
    public int _pageSize { get; set; } = 10;
}
