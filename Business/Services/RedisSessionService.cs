using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using ServiceStack.Redis;

namespace Business.Services
{
    public class RedisSessionService : IRedisSessionService
    {
        private IRedisClientsManagerAsync _redisClientsManagerAsync;
        
        public RedisSessionService(IRedisClientsManagerAsync redisClientsManagerAsync)
        {
            _redisClientsManagerAsync = redisClientsManagerAsync;
        }

        public async Task<bool> ClearAsync()
        {
            try
            {
                await using var redis = await _redisClientsManagerAsync.GetClientAsync();
                await redis.FlushAllAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> ClearAsync(string key)
        {
            try
            {
                await using var redis = await _redisClientsManagerAsync.GetClientAsync();
                await redis.RemoveAsync(key);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string key)
        {
            try
            {
                await using var redis = await _redisClientsManagerAsync.GetClientAsync();
                await redis.RemoveAsync(key);
                return true;
            }
            catch (Exception)
            {
                return false;
            }   
        }

        public async Task<string> GetStringAsync(string key)
        {
            try
            {
                await using var redis = await _redisClientsManagerAsync.GetClientAsync();
                return await redis.GetAsync<string>(key);
            }
            catch (Exception)   
            {
                return null;
            }
        }

        public async Task<bool> IsExistsAsync(string key)
        {
            try
            {
                await using var redis = await _redisClientsManagerAsync.GetClientAsync();
                return await redis.ContainsKeyAsync(key);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> RefreshAsync(string key)
        {
            try
            {
                await using var redis = await _redisClientsManagerAsync.GetClientAsync();
                await redis.ExpireEntryInAsync(key, TimeSpan.FromMinutes(1));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task SetStringAsync(string key, string value, TimeSpan? absoluteExpiration = null, TimeSpan? unusedExpiration = null)
        {
            try
            {
                await using var redis = await _redisClientsManagerAsync.GetClientAsync();
                await redis.SetAsync(key, value, DateTime.Now.AddMinutes(1), CancellationToken.None);
            }
            catch (Exception)
            {
            }
        }
    }
}
