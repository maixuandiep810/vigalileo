using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vigalileo.Data.RepositoryPattern.IRepositories;
using vigalileo.Data.EF;
using vigalileo.Data.Entities;
using System.Linq.Expressions;
using System.Linq;

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

        public async Task<TEntity> GetByIdAsync(TPKey id)
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

        public async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var result = await entities.Where(predicate).ToListAsync();
                return result;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}