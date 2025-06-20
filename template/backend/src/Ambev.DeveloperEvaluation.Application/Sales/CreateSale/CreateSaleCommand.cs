using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;


public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    public Guid CustomerId { get; set; }
    public string Branch { get; set; } = string.Empty;

    public IEnumerable<CreateSaleItemsRequest> SaleItems = new List<CreateSaleItemsRequest>();

    public class CreateSaleItemsRequest
    {
        public Guid ProductId { get; set; } = Guid.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}