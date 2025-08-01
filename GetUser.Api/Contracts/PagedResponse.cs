namespace GetUser.Api.Contracts;

public class PagedResponse
{
    public required int Page { get; set; }
    public required int PageSize { get; set; }
    public required int Total { get; set; }
    public bool HasNextPage => Total > Page * PageSize;
}