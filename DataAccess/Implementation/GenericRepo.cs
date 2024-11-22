using DataAccess.Data;
using Domain.Entities;
using Domain.Repos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Implementation
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext _context;
        private DbSet<T> _dbSet;
        private readonly UserManager<ApplicationUser> _userManager;
        public GenericRepo(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public GenericRepo(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task AddAsync(T entity)
        {
           await _dbSet.AddAsync(entity);
           await SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await SaveChangesAsync();

        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, bool isTracking = true
            , params string[] includes)
        {
            var query = _dbSet.AsQueryable();
            if(filter != null)
            query = query.Where(filter);

            if(!isTracking)
                query = query.AsNoTracking();
            if(includes != null)
            {
                foreach(var include in includes)
                {
                    query =query.Include(include);
                }
            }

            return await query.ToListAsync();

        }

        public async Task<T> GetByIdAsync(int id) => (await _dbSet.FindAsync(id))!;
        

        public async Task UpdateAsync(T entity)
        {
           _dbSet.Update(entity);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
        
        
    }
}
