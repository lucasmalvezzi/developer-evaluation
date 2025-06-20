namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

public class ListSaleResult
{
    public Guid CustomerId { get; set; } = Guid.Empty;
    public int Id { get; set; }
    public string Branch { get; set; } = string.Empty;
    public bool IsCancelled { get; set; }
    public DateTime SaleDate { get; set; }
    public IEnumerable<ListSaleItemResult> SaleItems { get; set; } = new List<ListSaleItemResult>();
    public decimal TotalAmount { get; set; }


    public class ListSaleItemResult
    {
        public ListSaleProductResult Product { get; set; } = new ListSaleProductResult();
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
    public class ListSaleProductResult
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Title { get; set; } = string.Empty;
    }
}
