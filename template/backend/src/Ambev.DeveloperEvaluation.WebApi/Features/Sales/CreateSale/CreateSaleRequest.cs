namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleRequest
{
    public Guid CustomerId { get; set; } 
    public string Branch { get; set; } = string.Empty;

    public IEnumerable<CreateSaleItemsRequest> SaleItems = new List<CreateSaleItemsRequest>();

    public class CreateSaleItemsRequest
    {
        public Guid ProductId { get; set; } = Guid.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}