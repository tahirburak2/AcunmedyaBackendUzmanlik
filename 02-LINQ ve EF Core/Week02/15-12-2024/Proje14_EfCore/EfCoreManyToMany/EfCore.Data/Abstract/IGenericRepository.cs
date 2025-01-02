using System;

namespace EfCore.Data.Abstract;
//Buradaki Tentity Category ya da Product gibi entitylerimizden bir olabilir
public interface IGenericRepository<TEntity>
{
Task<IEnumerable<TEntity>> GetAllAsync();
Task<TEntity> GetByIdAsync(int id);
Task AddAsync(TEntity entity);
Task UpdateAsync(TEntity entity);
Task DeleteAsync(TEntity entity);

}
