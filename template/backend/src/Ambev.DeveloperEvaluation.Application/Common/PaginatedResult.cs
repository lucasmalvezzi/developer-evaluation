namespace Ambev.DeveloperEvaluation.Application.Common;

public class PaginatedResult<T> 
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
    public IList<T> Items { get; set; } = [];
}