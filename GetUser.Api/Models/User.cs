using System.Text.Json.Serialization;

namespace GetUser.Api.Models;

public class User
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

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
    
    [JsonPropertyName("weight")] 
    public double Weight { get; set; }
    
    [JsonPropertyName("eyeColor")] 
    public string EyeColor { get; set; }
    
    [JsonPropertyName("hair")] 
    public Hair Hair { get; set; }
    
    [JsonPropertyName("ip")] 
    public string Ip { get; set; }
    
    [JsonPropertyName("address")] 
    public Address Address { get; set; }
    
    [JsonPropertyName("macAddress")] 
    public string MacAddress { get; set; }
    
    [JsonPropertyName("university")] 
    public string University { get; set; }
    
    [JsonPropertyName("bank")] 
    public Bank Bank { get; set; }
    
    [JsonPropertyName("company")] 
    public Company Company { get; set; }
    
    [JsonPropertyName("ein")] 
    public string Ein { get; set; }
    
    [JsonPropertyName("ssn")] 
    public string Ssn { get; set; }
    
    [JsonPropertyName("userAgent")] 
    public string UserAgent { get; set; }
    
    [JsonPropertyName("crypto")] 
    public Crypto Crypto { get; set; }
    
    [JsonPropertyName("role")] 
    public string Role { get; set; }
}