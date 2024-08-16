using BaseProject.Application.Abstractions.Token;
using BaseProject.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProject.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddBaseProjectInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
