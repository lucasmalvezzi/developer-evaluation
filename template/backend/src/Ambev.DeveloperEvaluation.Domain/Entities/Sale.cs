using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity<int>
{
    public User? Customer { get; set; } 
    public Guid CustomerId { get; set; } = Guid.Empty;
    public string Branch { get; set; } = string.Empty;
    public bool IsCancelled { get; set; }
    public DateTime SaleDate { get; set; }

    public IEnumerable<SaleItem> SaleItems { get; set; } = new List<SaleItem>();

    public decimal TotalAmount => SaleItems.Sum(i => i.Total);
    protected Sale()
    {
        SaleDate = DateTime.UtcNow;
    }
    public Sale(DateTime saleDate, User customer, string branch)
    {
        SaleDate = saleDate;
        Customer = customer;
        Branch = branch;
        IsCancelled = false;
    }
    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
    public void Cancel()
    {
        IsCancelled = true;
    }
}