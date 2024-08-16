using GControl.Application.Abstractions.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GControl.Infrastructure.Services
{
    public static class ServiceRegistration
    {
        public static void AddGControlInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IBaseProjectService, BaseProjectService>();
        }
    }
}
