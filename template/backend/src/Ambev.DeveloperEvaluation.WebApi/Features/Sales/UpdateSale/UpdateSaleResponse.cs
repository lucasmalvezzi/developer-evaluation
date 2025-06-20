namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

public class UpdateSaleResponse
{
    public Guid CustomerId { get; set; } = Guid.Empty;
    public int Id { get; set; }
    public string Branch { get; set; } = string.Empty;
    public bool IsCancelled { get; set; }
    public DateTime SaleDate { get; set; }

    public IEnumerable<UpdateSaleItemResponse> SaleItems { get; set; } = new List<UpdateSaleItemResponse>();
    public decimal TotalAmount { get; set; }

    public class UpdateSaleItemResponse
    {
        public UpdateSaleProductResponse Product { get; set; } = new UpdateSaleProductResponse();
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
    public class UpdateSaleProductResponse
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Title { get; set; } = string.Empty;
    }
}
