namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleResult
{
    public Guid CustomerId { get; set; } = Guid.Empty;
    public int Id { get; set; }
    public string Branch { get; set; } = string.Empty;
    public bool IsCancelled { get; set; }
    public DateTime SaleDate { get; set; }
    public IEnumerable<CreateSaleItemResult> SaleItems { get; set; } = new List<CreateSaleItemResult>();
    public decimal TotalAmount { get; set; }


    public class CreateSaleItemResult
    {
        public CreateSaleProductResult Product { get; set; } = new CreateSaleProductResult();
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
    public class CreateSaleProductResult
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Title { get; set; } = string.Empty;
    }
}
