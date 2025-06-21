using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
public class ListSaleRequest
{
    [FromQuery]
    public Guid? CustomerId { get; set; } = null;
    [FromQuery]
    public string? Branch { get; set; } = null;
    [FromQuery]
    public bool? IsCancelled { get; set; } = null;
    [FromQuery]
    public int _page { get; set; } = 1;
    [FromQuery]
    public int _pageSize { get; set; } = 10;
}
