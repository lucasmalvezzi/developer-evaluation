using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
public class ListSaleResponse
{
    public Guid CustomerId { get; set; } = Guid.Empty;
    public int Id { get; set; }
    public string Branch { get; set; } = string.Empty;
    public bool IsCancelled { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal TotalAmount { get; set; }

    public IEnumerable<ListSaleItemResponse> SaleItems { get; set; } = [];
    public class ListSaleItemResponse
    {
        public ListSaleProductResponse Product { get; set; } = new ListSaleProductResponse();
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
    public class ListSaleProductResponse
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Title { get; set; } = string.Empty;
    }

}
