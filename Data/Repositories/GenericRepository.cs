using Core.Entities.Bases;
using Core.Interfaces.Repositories;
using Data.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        protected YouDbContext _context { get; set; }
        public DbSet<T> _entity { get; set; }

        public GenericRepository(YouDbContext youRepo)
        {
            _context = youRepo;
            _entity = _context.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            await _entity.AddAsync(entity);

            var result = await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<bool> Delete(int id)
        {
            var dbEntity = _entity.Find(id);

            var result = _entity.Remove(dbEntity);

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> ExistsAsync(int id)
        {
            var result = await _context.FindAsync<T>(id);
            return result != null;
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _entity.ToListAsync();
            return result;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            var dbEntity = await _entity.FindAsync(id);
            return dbEntity;
        }
        public async Task<T> Update(T entity)
        {
            _entity.Update(entity); ;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
