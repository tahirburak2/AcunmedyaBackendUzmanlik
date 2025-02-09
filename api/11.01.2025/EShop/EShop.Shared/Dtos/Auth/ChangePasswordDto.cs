using System;

namespace EShop.Shared.Dtos.Auth;

public class ChangePasswordDto
{
public string? UserName { get; set; }
public string? CurrentPassword { get; set; }
public string? NewPassword { get; set; }
public string? ConfirmPassword { get; set; }
}
