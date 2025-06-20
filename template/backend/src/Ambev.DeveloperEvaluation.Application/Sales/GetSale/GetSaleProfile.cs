using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Users.GetUser;

public class GetSaleProfile : Profile
{

    public GetSaleProfile()
    {
        CreateMap<Sale, GetSaleResult>();
        CreateMap<SaleItem, GetSaleResult.GetSaleItemResult>();
        CreateMap<Product, GetSaleResult.GetSaleProductResult>();
    }
}
