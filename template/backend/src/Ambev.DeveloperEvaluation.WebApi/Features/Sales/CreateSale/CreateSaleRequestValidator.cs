using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;


public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{

    public CreateSaleRequestValidator()
    {
        RuleFor(sale => sale.CustomerId).NotEmpty();
        RuleFor(sale => sale.Branch).NotEmpty().MaximumLength(100);
        RuleForEach(sale => sale.SaleItems).ChildRules(item =>
        {
            item.RuleFor(item => item.ProductId).NotEmpty();
            item.RuleFor(item => item.Quantity).GreaterThan(0);
            item.RuleFor(item => item.UnitPrice).GreaterThan(0);
        });

    }
}