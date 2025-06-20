using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

public class ListSaleProfile : Profile
{

    public ListSaleProfile()
    {
        CreateMap<Sale, ListSaleResult>();
        CreateMap<SaleItem, ListSaleResult.ListSaleItemResult>();
        CreateMap<Product, ListSaleResult.ListSaleProductResult>();
    }
}
