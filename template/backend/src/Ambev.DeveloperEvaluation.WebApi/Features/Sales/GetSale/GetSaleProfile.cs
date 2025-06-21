using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSaleProfile : Profile
{

    public GetSaleProfile()
    {
        CreateMap<int,GetSaleCommand>()
            .ConstructUsing(id => new GetSaleCommand(id));
        CreateMap<GetSaleResult, GetSaleResponse>();
        CreateMap<GetSaleResult.GetSaleItemResult, GetSaleResponse.GetSaleItemResponse>();
        CreateMap<GetSaleResult.GetSaleProductResult, GetSaleResponse.GetSaleProductResponse>();
    }
}
