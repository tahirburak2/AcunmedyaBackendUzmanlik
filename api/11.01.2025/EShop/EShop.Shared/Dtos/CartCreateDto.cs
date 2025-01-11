using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.Shared.Dtos;

public class CartCreateDto
{
    [Required(ErrorMessage = "Kullanıcı Id'si zorunludur!")]
    public string? ApplicationUserId { get; set; }
}
