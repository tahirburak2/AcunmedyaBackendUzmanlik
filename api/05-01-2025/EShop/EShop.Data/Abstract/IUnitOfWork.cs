using System;

namespace EShop.Data.Abstract;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<TEntity> GetRepository<TEntity>
}
