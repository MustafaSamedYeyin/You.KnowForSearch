using ServiceStack.Redis;
using System.Text.Json;

namespace API.Services
{
    public interface IRedisSessionService
    {
        Task<T?> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value, TimeSpan? expiry = null);
        Task RemoveAsync(string key);
    }

    public class RedisSessionService : IRedisSessionService
    {
        private readonly IRedisClientsManagerAsync _redisManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RedisSessionService(IRedisClientsManagerAsync redisManager, IHttpContextAccessor httpContextAccessor)
        {
            _redisManager = redisManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            await using var redis = await _redisManager.GetClientAsync();
            var value = await redis.GetAsync<string>(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
        {
            await using var redis = await _redisManager.GetClientAsync();
            var serializedValue = JsonSerializer.Serialize(value);
            await redis.SetAsync(key, serializedValue, DateTime.Now.Add(expiry ?? TimeSpan.FromMinutes(10)));
        }

        public async Task RemoveAsync(string key)
        {
            await using var redis = await _redisManager.GetClientAsync();
            await redis.RemoveAsync(key);
        }
    }
} 