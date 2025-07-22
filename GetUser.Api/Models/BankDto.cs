namespace GetUser.Api.Models;

public class BankDto
{
    public string CardExpire { get; set; }
    public string CardNumber { get; set; }
    public string CardType { get; set; }
    public string Currency { get; set; }
    public string Iban { get; set; }
}