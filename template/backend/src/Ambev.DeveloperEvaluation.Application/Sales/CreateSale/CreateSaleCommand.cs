using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;


public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    public Guid CustomerId { get; set; }
    public string Branch { get; set; } = string.Empty;

    public IEnumerable<CreateSaleItemsCommand> SaleItems { get; set; } = new List<CreateSaleItemsCommand>();

    public class CreateSaleItemsCommand
    {
        public Guid ProductId { get; set; } = Guid.Empty;
        public int Quantity { get; set; }
    }
}