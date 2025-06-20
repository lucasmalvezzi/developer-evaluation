using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class ListSaleRequestValidator : AbstractValidator<ListSaleRequest>
{
    public ListSaleRequestValidator()
    {
        RuleFor(x => x._page)
            .NotEmpty()
            .WithMessage("Page is required");
        RuleFor(x => x._pageSize).NotEmpty()
            .GreaterThan(0)
            .WithMessage("Page size is required");
    }
}
