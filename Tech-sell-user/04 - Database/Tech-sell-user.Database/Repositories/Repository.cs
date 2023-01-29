using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tech_sell_user.Database.Context;
using Tech_sell_user.Database.Interface;

namespace Tech_sell_user.Database.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public readonly TechSellUserContext _context;

        protected Repository(TechSellUserContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            var entitySaved = (await _context.Set<TEntity>().AddAsync(entity)).Entity;
            return entitySaved;
        }

        public virtual async Task BulkInsertAsync(List<TEntity> entities)
        {
            await _context.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public virtual async Task BulkUpdateAsync(List<TEntity> entities)
        {
            _context.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(string id)
        {
            var element = await GetByIdAsync(id);

            if (element == null) return;

            _context.Set<TEntity>().Remove(element);
        }

        public virtual async Task DeleteAsync(TEntity element)
        {

            if (element == null) return;

            _context.Set<TEntity>().Remove(element);
        }

        public async Task<List<TEntity>> GetAllAsync(Func<TEntity, bool> predicate, string[] expands)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (expands is not null)
            {
                foreach (var exp in expands)
                    query = query.Include(exp);
            }

            if (predicate is not null)
                return query.Where(predicate).ToList();
            else
                return await query.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(string id)
        {
            return await _context.GetDbSet<TEntity>().FindAsync(id);
        }

        public virtual async Task UpdateAsync(TEntity entity, string id)
        {
            if (entity == null) return;
            var existing = await GetByIdAsync(id);

            if (existing != null)
                _context.Entry(existing).CurrentValues.SetValues(entity);
        }

        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> expression = null, string[] expands = null, bool withTracking = false)
        {
            IQueryable<TEntity> query;

            if (withTracking)
                query = _context.Set<TEntity>();
            else
                query = _context.Set<TEntity>().AsNoTracking();

            if (expands != default)
            {
                foreach (var exp in expands)
                    query = query.Include(exp);
            }

            if (expression == null)
                return query;

            return query.Where(expression);
        }

        public virtual IQueryable<TEntity> QueryWithTracking(string[] expands = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (expands != default || expands != null)
            {
                foreach (var exp in expands)
                    query = query.Include(exp);
            }

            return query;
        }
    }
}