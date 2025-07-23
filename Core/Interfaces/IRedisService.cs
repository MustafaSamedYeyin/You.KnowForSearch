using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRedisSessionService
    {
        Task<string> GetStringAsync(string key);
        Task SetStringAsync(string key, string value, TimeSpan? absoluteExpiration = null, TimeSpan? unusedExpiration = null);
        Task<bool> DeleteAsync(string key);
        Task<bool> IsExistsAsync(string key);
        Task<bool> RefreshAsync(string key);
        Task<bool> ClearAsync();
        Task<bool> ClearAsync(string key);
    }
}
