
namespace Ambev.DeveloperEvaluation.Domain.Common;
public class PaginatedEntity<T>
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
    public IList<T> Items { get; set; } = [];
}
