using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Common;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

public class ListSaleHandler : IRequestHandler<ListSaleCommand, PaginatedResult<ListSaleResult>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public ListSaleHandler(
        ISaleRepository saleRepository,
        IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedResult<ListSaleResult>> Handle(ListSaleCommand command, CancellationToken cancellationToken)
    {
        var sales = await _saleRepository.GetAllPaginatedAsync(
            command.CustomerId,
            command.Branch,
            command.IsCancelled,
            command._page,
            command._pageSize,
            cancellationToken);

        return _mapper.Map<PaginatedResult<ListSaleResult>>(sales);
    }
}
