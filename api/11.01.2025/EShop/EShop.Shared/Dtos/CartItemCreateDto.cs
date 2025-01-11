using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.Shared.Dtos;

public class CartItemCreateDto
{
    [Required(ErrorMessage = "Sepet Id'si zorunludur!")]
    public int CartId { get; set; }
    [Required(ErrorMessage = "Ürün Id'si zorunludur!")]
    public int ProductId { get; set; }
    [Required(ErrorMessage = "Ürün adedi zorunludur!")]
    public int Quantity { get; set; }
}
