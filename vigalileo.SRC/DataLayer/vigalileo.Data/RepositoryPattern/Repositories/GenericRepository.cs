using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vigalileo.Data.RepositoryPattern.IRepositories;
using vigalileo.Data.EF;
using vigalileo.Data.Entities;

namespace vigalileo.Data.RepositoryPattern.Repositories
{
    public abstract class GenericRepository<TEntity, TPKey> : IGenericRepository<TEntity, TPKey> where TEntity : class, IBaseEntity<TPKey>
    {
        protected readonly vigalileoDbContext _context;
        protected readonly DbSet<TEntity> entities;

        public GenericRepository(vigalileoDbContext context)
        {
            _context = context;
            entities = _context.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(TPKey id)
        {
            try
            {
                return await entities.FindAsync(id);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                return await entities.ToListAsync();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            try
            {
                var result = await entities.AddAsync(entity);
                return 1;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public int Update(TEntity entity)
        {
            try
            {
                entities.Update(entity);
                return 1;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        public void Delete(TEntity entity)
        {
            try
            {
                entities.Remove(entity);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}