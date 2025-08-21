using System.Text.Json.Serialization;
using GetUser.Api.Models;

namespace GetUser.Api.Contracts;

public class CreateUserRequest
{
    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("image")]
    public Uri Image { get; set; }

    [JsonPropertyName("accessToken")]
    public string AccessToken { get; set; }

    [JsonPropertyName("refreshToken")]
    public string RefreshToken { get; set; }

    [JsonPropertyName("maidenName")] 
    public string MaidenName { get; set; }
    
    [JsonPropertyName("age")] 
    public int Age { get; set; }
    
    [JsonPropertyName("phone")] 
    public string Phone { get; set; }
    
    [JsonPropertyName("password")] 
    public string Password { get; set; }
    
    [JsonPropertyName("birthDate")] 
    public string BirthDate { get; set; }
    
    [JsonPropertyName("bloodGroup")] 
    public string BloodGroup { get; set; }
    
    [JsonPropertyName("height")] 
    public double Height { get; set; }
    
    [JsonPropertyName("ip")] 
    public string Ip { get; set; }
    
    [JsonPropertyName("address")] 
    public Address Address { get; set; }
    
    [JsonPropertyName("macAddress")] 
    public string MacAddress { get; set; }
    
    [JsonPropertyName("university")] 
    public string University { get; set; }
    
    [JsonPropertyName("bank")] 
    public BankRequest Bank { get; set; }
    
    [JsonPropertyName("company")] 
    public CompanyRequest Company { get; set; }
    
    [JsonPropertyName("ein")] 
    public string Ein { get; set; }
    
    [JsonPropertyName("ssn")] 
    public string Ssn { get; set; }
    
    [JsonPropertyName("userAgent")] 
    public string UserAgent { get; set; }
    
    [JsonPropertyName("role")] 
    public string Role { get; set; }
}

public class CompanyRequest
{
    [JsonPropertyName("department")]
    public string Department { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("address")]
    public Address Address { get; set; }
}

public class BankRequest
{
    [JsonPropertyName("cardExpire")]
    public string CardExpire { get; set; }

    [JsonPropertyName("cardNumber")]
    public string CardNumber { get; set; }

    [JsonPropertyName("cardType")]
    public string CardType { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    [JsonPropertyName("iban")]
    public string Iban { get; set; }
}