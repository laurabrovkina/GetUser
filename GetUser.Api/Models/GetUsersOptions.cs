namespace GetUser.Api.Models;

public class GetUsersOptions
{
    public string? Name { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}