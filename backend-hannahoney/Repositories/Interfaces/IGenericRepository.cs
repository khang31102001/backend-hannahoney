
namespace backend_hannahoney
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        void Add(T entity);
        void Remove(Guid id);
        void Update(T entity);
    } 
}