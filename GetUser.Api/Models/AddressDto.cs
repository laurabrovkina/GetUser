namespace GetUser.Api.Models;

public class AddressDto
{
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string StateCode { get; set; }
    public int PostalCode { get; set; }
    public CoordinatesDto Coordinates { get; set; }
    public string Country { get; set; }
}