using BepopAppServer.Entity.Entities.Common;
using System.Linq.Expressions;

namespace BepopAppServer.DAL.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
