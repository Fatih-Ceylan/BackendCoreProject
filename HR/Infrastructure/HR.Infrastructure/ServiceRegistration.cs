using HR.Infrastructure.ElasticSearch.Interface;
using HR.Infrastructure.ElasticSearch.Services;
using Microsoft.Extensions.DependencyInjection;
using Nest;

namespace HR.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddHRInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IElasticSearchService, ElasticSearchService>();
            services.AddSingleton<IElasticClient, ElasticClient>();
        }
    }
}
