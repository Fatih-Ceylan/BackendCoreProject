namespace Utilities.Infrastructure.UtilityInfrastructure.Services.RedisCache.InterFaces
{
    public interface IRedisCacheService
    {
        Task<string> GetValueAsync(string key);
        Task<bool> SetValueAsync(string key, string value, TimeSpan? expireTime);
        Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> action, TimeSpan? expireTime) where T : class;
        T GetOrAdd<T>(string key, Func<T> action, TimeSpan? expireTime) where T : class;
        Task Clear(string key);
        void ClearAll();
    }
}
