using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace EShop.Shared.Dtos;

public class ProductCreateDto
{
    [Required(ErrorMessage = "Ürün adı zorunludur!")]
    [StringLength(100, ErrorMessage = "Ürün adı en fazla 100 karakter olmalıdır!")]
    public string? Name { get; set; }


    [Required(ErrorMessage = "Özellikler zorunludur!")]
    [StringLength(10000, ErrorMessage = "Özellikler en fazla 10000 karakter olmalıdır!")]
    public string? Properties { get; set; }


    [Required(ErrorMessage = "Fiyat zorunludur!")]
    [Range(0.00001, double.MaxValue, ErrorMessage = "Fiyat 0'dan büyük olmalıdır!")]
    public decimal? Price { get; set; }

    [Required(ErrorMessage = "Ürün resmi zorunludur!")]
    public IFormFile? Image { get; set; }

    [Required(ErrorMessage = "Her ürün için en az bir kategori zorunludur!")]
    public ICollection<int>? CategoryIds { get; set; }=new HashSet<int>();
}
