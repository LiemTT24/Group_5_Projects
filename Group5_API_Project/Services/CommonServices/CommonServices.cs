using Microsoft.EntityFrameworkCore;

namespace Group5_API_Project.Services.CommonServices
{
    public class CommonServices<TDbContext, TEntity> : ICommonServices<TEntity> where TDbContext : DbContext where TEntity : class
    {

        private readonly TDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public CommonServices(TDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<bool> AnyAsync(int id)
        {
            var result = await _dbSet.FindAsync(id);
            return result != null;
        }

        public async Task<bool> CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            var result = await _context.SaveChangesAsync();
            return Convert.ToBoolean(result);
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            var result = await _context.SaveChangesAsync();
            return Convert.ToBoolean(result);
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return Task.FromResult(_dbSet.ToList());
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            var result = await _context.SaveChangesAsync();
            return Convert.ToBoolean(result);
        }
    }
}
