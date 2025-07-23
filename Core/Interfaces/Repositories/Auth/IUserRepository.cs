using Core.Interfaces.Repositories;

namespace UserSpace;
public interface IUserRepository : IGenericRepository<User>
{
    Task<User> GetByEmailAsync(string email);
}