using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;


public class UpdateSaleProfile : Profile
{
    public UpdateSaleProfile()
    {
        CreateMap<Sale, UpdateSaleResult>();
        CreateMap<SaleItem, UpdateSaleResult.UpdateSaleItemResult>();
        CreateMap<Product, UpdateSaleResult.UpdateSaleProductResult>();
    }
}
