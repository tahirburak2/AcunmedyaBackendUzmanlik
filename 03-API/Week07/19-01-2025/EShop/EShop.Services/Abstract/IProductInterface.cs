using System;
using EShop.Shared.Dtos;
using EShop.Shared.Dtos.ResponseDtos;

namespace EShop.Services.Abstract;

public interface IProductInterface
{
    Task<ResponseDto<ProductDto>> GetAsync(int id);
    
}
