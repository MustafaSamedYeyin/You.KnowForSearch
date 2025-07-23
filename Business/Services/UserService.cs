using Core.Interfaces;

namespace UserSpace;

public class UserService : IUserService
{
    public IUserRepository _userService { get; set; }
    public UserService(IUserRepository userService)
    {
        _userService = userService;
    }

    public async Task<User> AddAsync(User entity)
    {
        var emailAldreadyExist = GetByEmailAsync(entity.Email);
        if (emailAldreadyExist != null)
        {
            throw new Exception("Already email exist.");
        }
        return await _userService.AddAsync(entity);
    }

    public async Task<bool> Delete(int id)
    {
        return await _userService.Delete(id);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _userService.ExistsAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _userService.GetAllAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _userService.GetByIdAsync(id);
    }

    public async Task<User> Update(User entity)
    {
        return await _userService.Update(entity);
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await _userService.GetByEmailAsync(email);
    }
}