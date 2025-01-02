using System;
using EfCore.Shared.Dtos;


namespace EfCore.Business.Abstract;

public interface ICategoryService
{
    Task<CategoryDto> CreateAsync(CategoryCreateDto categoryCreateDto);
    Task<CategoryDto> UpdateAsync(CategoryUpdateDto categoryUpdateDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<CategoryDto>> GetCategories();
    Task<IEnumerable<CategoryDto>> GetCategories(bool IsDeleted);
Task<CategoryDto> GetByIdAsync(int id);
    
}
