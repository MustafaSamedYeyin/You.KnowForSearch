using Data.Repositories;
using Data.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace UserSpace;
public class UserRepository: GenericRepository<User>, IUserRepository
{
    public UserRepository(YouDbContext youRepo) : base(youRepo)
    {
    }

    public async Task<User> GetByEmailAsync(string email) 
    {
        var result = _context.Users.ToList();
        return await _context.Users.Where(i => i.Email == email).FirstOrDefaultAsync();
    }
}
