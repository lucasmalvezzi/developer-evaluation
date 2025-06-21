using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

public class ListSaleProfile : Profile
{

    public ListSaleProfile()
    {
        CreateMap<PaginatedEntity<Sale>, PaginatedResult<ListSaleResult>>();
        CreateMap<Sale, ListSaleResult>();
        CreateMap<SaleItem, ListSaleResult.ListSaleItemResult>();
        CreateMap<Product, ListSaleResult.ListSaleProductResult>();
    }
}
