using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserSpace;
public interface IUserService
{
    public Task<User> GetByIdAsync(int id);
    public Task<User> GetByEmailAsync(string email);
    public Task<IEnumerable<User>> GetAllAsync();
    public Task<User> AddAsync(User entity);
    public Task<User> Update(User entity);
    public Task<bool> Delete(int id);
    public Task<bool> ExistsAsync(int id);
}
