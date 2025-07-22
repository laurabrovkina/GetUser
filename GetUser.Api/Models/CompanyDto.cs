namespace GetUser.Api.Models;

public class CompanyDto
{
    public string Department { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public AddressDto Address { get; set; }
}