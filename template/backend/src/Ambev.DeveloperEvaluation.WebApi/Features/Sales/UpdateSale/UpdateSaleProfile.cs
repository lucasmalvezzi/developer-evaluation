using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

public class UpdateSaleProfile : Profile
{

    public UpdateSaleProfile()
    {
        CreateMap<UpdateSaleRequest, UpdateSaleCommand>();
        CreateMap<UpdateSaleRequest.UpdateSaleItemsRequest, UpdateSaleCommand.UpdateSaleItemsCommand>();
        CreateMap<UpdateSaleResult, UpdateSaleResponse>();
        CreateMap<UpdateSaleResult.UpdateSaleItemResult, UpdateSaleResponse.UpdateSaleItemResponse>();
        CreateMap<UpdateSaleResult.UpdateSaleProductResult, UpdateSaleResponse.UpdateSaleProductResponse>();
    }
}
