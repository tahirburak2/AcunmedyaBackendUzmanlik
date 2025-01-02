using System;
using EfCore.Business.Abstract;
using EfCore.Shared.Dtos;

namespace EfCore.Business.Concrete;

public class CategoryService : ICategoryService
{
    public Task<CategoryDto> CreateAsync(CategoryCreateDto categoryCreateDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CategoryDto>> GetCategories()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CategoryDto>> GetCategories(bool IsDeleted)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryDto> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
    {
        throw new NotImplementedException();
    }
}
