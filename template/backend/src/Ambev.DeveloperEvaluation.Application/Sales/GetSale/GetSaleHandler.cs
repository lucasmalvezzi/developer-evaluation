using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleHandler : IRequestHandler<GetSaleCommand, GetSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public GetSaleHandler(
        ISaleRepository saleRepository,
        IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<GetSaleResult> Handle(GetSaleCommand command, CancellationToken cancellationToken)
    {
        var user = await _saleRepository.GetByIdAsync(command.Id, cancellationToken);
        if (user == null)
            throw new KeyNotFoundException($"Sale with ID {command.Id} not found");

        return _mapper.Map<GetSaleResult>(user);
    }
}
