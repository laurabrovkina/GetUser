namespace GetUser.Api.Contracts;

public class PagedResponse
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int Total { get; set; }
    public bool HasNextPage => Total > Page * PageSize;
}