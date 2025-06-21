using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;


public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
{

    public UpdateSaleRequestValidator()
    {
        RuleFor(sale => sale.Id).NotEmpty().WithMessage("Sale ID must not be empty.");
        RuleFor(sale => sale.CustomerId).NotEmpty();
        RuleFor(sale => sale.Branch).NotEmpty().MaximumLength(100);
        RuleForEach(sale => sale.SaleItems).ChildRules(item =>
        {
            item.RuleFor(item => item.ProductId).NotEmpty();
            item.RuleFor(item => item.Quantity).GreaterThan(0);
        });

    }
}