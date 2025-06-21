namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSaleResponse
{
    public Guid CustomerId { get; set; } = Guid.Empty;
    public int Id { get; set; }
    public string Branch { get; set; } = string.Empty;
    public bool IsCancelled { get; set; }
    public DateTime SaleDate { get; set; }

    public IEnumerable<GetSaleItemResponse> SaleItems { get; set; } = new List<GetSaleItemResponse>();
    public decimal TotalAmount { get; set; }

    public class GetSaleItemResponse
    {
        public GetSaleProductResponse Product { get; set; } = new GetSaleProductResponse();
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
    public class GetSaleProductResponse
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Title { get; set; } = string.Empty;
    }
}
