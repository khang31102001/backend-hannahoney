
using backend_hannahoney.data;
using Microsoft.EntityFrameworkCore;

namespace backend_hannahoney
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HoneyDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(HoneyDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>(); 

        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}