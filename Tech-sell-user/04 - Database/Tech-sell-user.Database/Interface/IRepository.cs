using System.Linq.Expressions;

namespace Tech_sell_user.Database.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(string id);
        
        Task<List<T>> GetAllAsync(Func<T, bool> predicate = null, string[] expands = null);
        
        Task<T> CreateAsync(T entity);
        
        Task UpdateAsync(T entity, string id);
        
        Task DeleteAsync(string id);
        
        Task DeleteAsync(T entity);
        
        Task BulkInsertAsync(List<T> entities);
        
        Task BulkUpdateAsync(List<T> entities);
        
        IQueryable<T> Query(Expression<Func<T, bool>> expression = null, string[] expands = null, bool withTracking = false);
        
        IQueryable<T> QueryWithTracking(string[] expands = null);
    }
}