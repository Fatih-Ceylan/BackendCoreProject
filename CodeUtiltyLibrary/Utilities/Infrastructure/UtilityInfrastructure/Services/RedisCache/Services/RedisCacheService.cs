using StackExchange.Redis;
using System.Text.Json;
using Utilities.Infrastructure.UtilityInfrastructure.Services.RedisCache.InterFaces;

namespace Utilities.Infrastructure.UtilityInfrastructure.Services.RedisCache.Services
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IConnectionMultiplexer _redisConnection;
        private readonly IDatabase _redisDB;

        //private TimeSpan ExpireTime => TimeSpan.FromDays(1);

        public RedisCacheService(IConnectionMultiplexer redisConnection)
        {
            _redisConnection = redisConnection;
            _redisDB = redisConnection.GetDatabase();
        }
        public async Task Clear(string key)
        {
            await _redisDB.KeyDeleteAsync(key);
        }

        public void ClearAll()
        {
            var redisEndpoints = _redisConnection.GetEndPoints(true);
            foreach (var redisEndpoint in redisEndpoints)
            {
                var redisServer = _redisConnection.GetServer(redisEndpoint);
                redisServer.FlushAllDatabases();
            }
        }

        public async Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> action, TimeSpan? expireTime) where T : class
        {
            var result = await _redisDB.StringGetAsync(key);
            if (result.IsNullOrEmpty)
            {
                result = JsonSerializer.SerializeToUtf8Bytes(await action());
                await SetValueAsync(key, result, expireTime);
            }

            return JsonSerializer.Deserialize<T>(result);
        }
        public T GetOrAdd<T>(string key, Func<T> action, TimeSpan? expireTime) where T : class
        {
            var result = _redisDB.StringGet(key);
            if (result.IsNull)
            {
                result = JsonSerializer.SerializeToUtf8Bytes(action());
                _redisDB.StringSet(key, result, TimeSpan.FromMinutes(10));
            }

            return JsonSerializer.Deserialize<T>(result);
        }

        public async Task<string> GetValueAsync(string key)
        {
            return await _redisDB.StringGetAsync(key);
        }

        public async Task<bool> SetValueAsync(string key, string value, TimeSpan? expireTime)
        {
            return await _redisDB.StringSetAsync(key, value, expireTime);
        }
    }
}
