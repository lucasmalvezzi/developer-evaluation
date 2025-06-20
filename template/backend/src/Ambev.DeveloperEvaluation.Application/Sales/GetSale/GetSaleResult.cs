namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleResult
{
    public Guid CustomerId { get; set; } = Guid.Empty;
    public int Id { get; set; }
    public string Branch { get; set; } = string.Empty;
    public bool IsCancelled { get; set; }
    public DateTime SaleDate { get; set; }
    public IEnumerable<GetSaleItemResult> SaleItems { get; set; } = new List<GetSaleItemResult>();
    public decimal TotalAmount { get; set; }


    public class GetSaleItemResult
    {
        public GetSaleProductResult Product { get; set; } = new GetSaleProductResult();
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
    public class GetSaleProductResult
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Title { get; set; } = string.Empty;
    }
}
