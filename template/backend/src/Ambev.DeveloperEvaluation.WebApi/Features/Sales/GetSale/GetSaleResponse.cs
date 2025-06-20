namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSaleResponse
{
    public Guid CustomerId { get; set; } = Guid.Empty;
    public int Id { get; set; }
    public string Branch { get; set; } = string.Empty;
    public bool IsCancelled { get; set; }
    public DateTime SaleDate { get; set; }

    public IEnumerable<CreateSaleItemResponse> SaleItems { get; set; } = new List<CreateSaleItemResponse>();
    public decimal TotalAmount { get; set; }

    public class CreateSaleItemResponse
    {
        public CreateSaleProductResponse Product { get; set; } = new CreateSaleProductResponse();
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
    public class CreateSaleProductResponse
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Title { get; set; } = string.Empty;
    }
}
