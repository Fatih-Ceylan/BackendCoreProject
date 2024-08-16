using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Platform.Application.Models;

namespace Platform.Application
{
    public static class ServiceRegistration
    {
        public static void AddPlatformApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
