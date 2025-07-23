namespace GetUser.Api.Contracts;

public class GetUsersRequest : PagedRequest
{
    public string? Name { get; set; }
}