using GControl.Application.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GControl.Application
{
    public static class ServiceRegistration
    {
        public static void AddGControlApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}