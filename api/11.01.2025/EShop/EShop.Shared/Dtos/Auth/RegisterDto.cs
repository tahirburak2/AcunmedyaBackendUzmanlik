using System;
using EShop.Shared.ComplexTypes;

namespace EShop.Shared.Dtos.Auth;

public class RegisterDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public GenderType Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Email { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
    public string? Role { get; set; }="User";

}
