using Ambev.DeveloperEvaluation.Common.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Common;

public class BaseEntity<T>: IComparable<BaseEntity<T>> where T : IComparable<T>
{
    public T Id { get; set; }

    public Task<IEnumerable<ValidationErrorDetail>> ValidateAsync()
    {
        return Validator.ValidateAsync(this);
    }

    public int CompareTo(BaseEntity<T>? other)
    {
        if (other == null)
        {
            return 1;
        }

        return Id.CompareTo(other.Id); 
    }
}
