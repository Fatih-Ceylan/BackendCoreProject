using BaseProject.Application.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProject.Application
{
    public static class ServiceRegistration
    {
        public static void AddBaseProjectApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}