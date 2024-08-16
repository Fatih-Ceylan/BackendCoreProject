using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;


namespace Utilities.Infrastructure.UtilityInfrastructure.Services.RedisCache.Services
{
    public static class RedisServiceExtensions
        {
            public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration)
            {
                var multiplexer = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
                services.AddSingleton<IConnectionMultiplexer>(multiplexer);
                return services;
            }
        }
}
