using System;
using System.Reflection.Metadata;
using EfCore.Entity.Concrete;
using EfCore.Shared.Dtos;

namespace EfCore.Business.Abstract;

public interface IProductService
{
Task<ProductDto> CreateAsync(ProductCreateDto productCreateDto);
Task<ProductDto> UpdateAsync(ProductUpdateDto productUpdateDto);
Task DeleteAsync(int id);
Task<IEnumerable<ProductDto>> GetProductsAsync();
Task<IEnumerable<ProductDto>> GetProductsAsync(bool IsDeleted);
Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync();
Task<ProductDto> GetByIdAsync(int id);


}
