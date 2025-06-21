namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleResult
{
    public Guid CustomerId { get; set; } = Guid.Empty;
    public int Id { get; set; }
    public string Branch { get; set; } = string.Empty;
    public bool IsCancelled { get; set; }
    public DateTime SaleDate { get; set; }
    public IEnumerable<UpdateSaleItemResult> SaleItems { get; set; } = new List<UpdateSaleItemResult>();
    public decimal TotalAmount { get; set; }


    public class UpdateSaleItemResult
    {
        public UpdateSaleProductResult Product { get; set; } = new UpdateSaleProductResult();
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
    public class UpdateSaleProductResult
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Title { get; set; } = string.Empty;
    }
}
