using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Validation;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using static Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.UpdateSaleCommand;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly IProductRepository _productRepository;
    private readonly ISaleRepository _saleRepository;
    private readonly IUserRepository _userRepository;
    private readonly ILogger<UpdateSaleHandler> _logger;
    private readonly IMapper _mapper;

    public UpdateSaleHandler(IProductRepository productRepository, IUserRepository userRepository, ISaleRepository saleRepository,IMapper mapper, ILogger<UpdateSaleHandler> logger)
    {
        _productRepository = productRepository;
        _saleRepository = saleRepository;
        _userRepository = userRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        var existingSale = await _saleRepository.GetByIdAsync(command.Id, cancellationToken);
        if (existingSale == null)
            throw new KeyNotFoundException($"Sale with ID {command.Id} not found");

        var customer = await _userRepository.GetByIdAsync(command.CustomerId, cancellationToken);
        if (customer == null)
            throw new KeyNotFoundException($"Customer not exists");

        var products = await _productRepository.GetByIds(command.SaleItems.Select(si=>si.ProductId), cancellationToken);

        command.SaleItems = command.SaleItems.GroupBy(si => si.ProductId).Select(si => new UpdateSaleItemsCommand
        {
            ProductId = si.Key,
            Quantity = si.Sum(x => x.Quantity)
        }).ToList();

        existingSale.CustomerId = command.CustomerId;
        existingSale.Branch = command.Branch;

        var cancelledItens = DeleteSaleItems(existingSale, command);
        UpdateSaleItems(existingSale, command);
        InsertSaleItems(existingSale, command);

        if(command.IsCancelled)
            existingSale.Cancel();

        foreach (var item in existingSale.SaleItems)
        {
            var product = products.FirstOrDefault(p => p.Id == item.ProductId);
            if (product == null)
                throw new KeyNotFoundException($"Product {item.ProductId} not exists");
            item.UnitPrice = product.Price;
        }

        var validator = new SaleValidator();
        var validationResult = validator.Validate(existingSale);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var updatedSale = await _saleRepository.UpdateAsync(existingSale, cancellationToken);

        if(updatedSale.IsCancelled)
            _logger.LogInformation("[Message Broker] Sale Cancelled with ID: {SaleId}", updatedSale.Id);
        else
           _logger.LogInformation("[Message Broker] Sale Modified with ID: {SaleId}", updatedSale.Id);

        if (cancelledItens.Any())
        {
            _logger.LogInformation("[Message Broker] Sale Items Cancelled: {CancelledItems}", string.Join(", ", cancelledItens.Select(ci => $"{ci.ProductId} (Qty: {ci.Quantity})")));
        }

        var result = _mapper.Map<UpdateSaleResult>(updatedSale);
        return result;
    }
    private void InsertSaleItems(Sale existingSale, UpdateSaleCommand command)
    {
        var commandProductIds = command.SaleItems.Select(csi => csi.ProductId).ToList();
        foreach (var item in command.SaleItems.Where(si => !existingSale.SaleItems.Any(ei => ei.ProductId == si.ProductId)))
        {
            existingSale.SaleItems.Add(new SaleItem
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
            });
        }
    }
    private void UpdateSaleItems(Sale existingSale, UpdateSaleCommand command)
    {
        var commandProductIds = command.SaleItems.Select(csi => csi.ProductId);
        foreach (var item in existingSale.SaleItems.Where(si=> commandProductIds.Contains((si.ProductId))))
        { 
            var commandItem = command.SaleItems.FirstOrDefault(csi => csi.ProductId == item.ProductId);
            if (commandItem != null)
            {
                item.Quantity = commandItem.Quantity;
            }

        }
    }
    private IList<SaleItem> DeleteSaleItems(Sale existingSale, UpdateSaleCommand command)
    {
        var canceledItems = new List<SaleItem>();
        var commandProductIds = command.SaleItems.Select(csi => csi.ProductId).ToList();
        var itensToRemove = existingSale.SaleItems.Where(si => !commandProductIds.Contains(si.ProductId)).ToList();
        foreach (var item in itensToRemove)
        {
            existingSale.SaleItems.Remove(item);
            canceledItems.Add(item);
        }
        return canceledItems;
    }
}
