using Core.Entities.Bases;

namespace Core.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class, new()
    {
        public Task<T> GetByIdAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> AddAsync(T entity);
        public Task<T> Update(T entity);
        public Task<bool> Delete(int id);
        public Task<bool> ExistsAsync(int id);
    }
}
