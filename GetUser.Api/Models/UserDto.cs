﻿namespace GetUser.Api.Models;

public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public Uri Image { get; set; }
    public string MaidenName { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
    public string BirthDate { get; set; }
    public string BloodGroup { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public string EyeColor { get; set; }
    public HairDto Hair { get; set; }
    public string Ip { get; set; }
    public AddressDto Address { get; set; }
    public string MacAddress { get; set; }
    public string University { get; set; }
    public BankDto Bank { get; set; }
    public CompanyDto Company { get; set; }
    public string Ein { get; set; }
    public string Ssn { get; set; }
    public string UserAgent { get; set; }
    public CryptoDto Crypto { get; set; }
    public string Role { get; set; }
    public int Skip { get; set; }
    public int Limit { get; set; }
    public int Total { get; set; }
}