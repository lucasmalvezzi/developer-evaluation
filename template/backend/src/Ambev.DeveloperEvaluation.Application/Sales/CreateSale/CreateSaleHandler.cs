using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Validation;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using static Ambev.DeveloperEvaluation.Application.Sales.CreateSale.CreateSaleCommand;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateUserHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly IProductRepository _productRepository;
    private readonly ISaleRepository _saleRepository;
    private readonly IUserRepository _userRepository;
    private readonly ILogger<CreateUserHandler> _logger;
    private readonly IMapper _mapper;

    public CreateUserHandler(IProductRepository productRepository, IUserRepository userRepository, ISaleRepository saleRepository,IMapper mapper, ILogger<CreateUserHandler> logger)
    {
        _productRepository = productRepository;
        _saleRepository = saleRepository;
        _userRepository = userRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var customer = await _userRepository.GetByIdAsync(command.CustomerId, cancellationToken);
        if (customer == null)
            throw new InvalidOperationException($"Customer not exists");

        var products = await _productRepository.GetByIds(command.SaleItems.Select(si=>si.ProductId), cancellationToken);

        command.SaleItems = command.SaleItems.GroupBy(si => si.ProductId).Select(si => new CreateSaleItemsCommand
        {
            ProductId = si.Key,
            Quantity = si.Sum(x => x.Quantity)
        }).ToList();

        var sale = _mapper.Map<Sale>(command);

        foreach (var item in sale.SaleItems)
        {
            var product = products.FirstOrDefault(p => p.Id == item.ProductId);
            if (product == null)
                throw new InvalidOperationException($"Product {item.ProductId} not exists");
            item.UnitPrice = product.Price;
        }

        var validator = new SaleValidator();
        var validationResult = validator.Validate(sale);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);

        _logger.LogInformation("[Message Broker] Sale created successfully with ID: {SaleId}", createdSale.Id);

        var result = _mapper.Map<CreateSaleResult>(createdSale);
        return result;
    }
}
