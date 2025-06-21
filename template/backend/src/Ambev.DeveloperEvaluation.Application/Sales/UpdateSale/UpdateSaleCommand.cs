using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;


public class UpdateSaleCommand : IRequest<UpdateSaleResult>
{
    public int Id { get; set; }
    public Guid CustomerId { get; set; }
    public string Branch { get; set; } = string.Empty;
    public bool IsCancelled { get; set; }
    public IEnumerable<UpdateSaleItemsCommand> SaleItems { get; set; } = new List<UpdateSaleItemsCommand>();

    public class UpdateSaleItemsCommand
    {
        public Guid ProductId { get; set; } = Guid.Empty;
        public int Quantity { get; set; }
    }
}