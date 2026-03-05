using BepopAppServer.DAL.Context;
using BepopAppServer.Entity.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BepopAppServer.DAL.Repositories
{
    public class GenericRepository<T>(AppDbContext _context) : IRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> _table = _context.Set<T>();
        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _table.AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _table;
            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
