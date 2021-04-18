using System.Collections.Generic;
using System.Threading.Tasks;

namespace vigalileo.Data.Core.Repositories
{
    public interface IGenericRepository<TEntity, TPKey> where TEntity : class
    {
        Task<TEntity> GetAsync(TPKey id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<int> AddAsync(TEntity entity);
        int Update(TEntity entity);
        void Delete(TEntity entity);

        // IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        // TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        // void AddRange(IEnumerable<TEntity> entities);
        // void RemoveRange(IEnumerable<TEntity> entities);
    }
}