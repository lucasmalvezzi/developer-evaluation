using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleForEach(Sale => Sale.SaleItems).ChildRules(saleItem =>
        {
            saleItem.RuleFor(item => item.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
            saleItem.RuleFor(item => item.Quantity)
               .LessThanOrEqualTo(20).WithMessage("It's not possible to sell above 20 identical items.");
            saleItem.RuleFor(item => item.UnitPrice)
                .GreaterThan(0).WithMessage("Unit price must be greater than 0.");
            saleItem.RuleFor(item => item.ProductId)
                .NotEmpty().WithMessage("Product must not be empty.");
        });

        RuleFor(sale => sale.CustomerId)
            .NotNull().WithMessage("Customer must not be empty.");

        RuleFor(sale => sale.Branch)
            .NotEmpty().MaximumLength(100).WithMessage("Branch must not be empty.");

        RuleFor(sale=> sale.SaleItems).Empty()
            .WithMessage("Sale must have at least one item.");
    }
}
