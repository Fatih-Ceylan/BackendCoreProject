using Microsoft.Extensions.DependencyInjection;
using Platform.Application.Abstractions.Token;
using Platform.Infrastructure.Services.Token;

namespace Platform.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddPlatformInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
