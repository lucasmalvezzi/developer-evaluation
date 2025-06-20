using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Application.Sales.ListSale;
using Ambev.DeveloperEvaluation.WebApi.Common;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class ListSaleProfile : Profile
{

    public ListSaleProfile()
    {
        CreateMap<ListSaleRequest, ListSaleCommand>();
       
        CreateMap<PaginatedResult<ListSaleResult>, PaginatedList<ListSaleResponse>>();
        CreateMap<ListSaleResult, ListSaleResponse>();
        CreateMap<ListSaleResult.ListSaleItemResult, ListSaleResponse.ListSaleItemResponse>();
        CreateMap<ListSaleResult.ListSaleProductResult, ListSaleResponse.ListSaleProductResponse>();
    }
}
