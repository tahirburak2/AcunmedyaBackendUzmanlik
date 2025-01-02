using System;
using EfCore.Entity.Concrete;

namespace EfCore.Data.Abstract;

public interface IProductRepository:IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
    Task<IEnumerable<Product>> GetAllDeletedProductsAsync(bool isDeleted=true);
}
