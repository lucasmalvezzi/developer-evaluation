using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

public class UpdateSaleRequest
{
    [FromRoute]
    public int Id { get; set; }
    public Guid CustomerId { get; set; } 
    public string Branch { get; set; } = string.Empty;

    public bool IsCancelled { get; set; }

    public IEnumerable<UpdateSaleItemsRequest> SaleItems { get; set; } = new List<UpdateSaleItemsRequest>();

    public class UpdateSaleItemsRequest
    {
        public Guid ProductId { get; set; } = Guid.Empty;
        public int Quantity { get; set; }
    }
}