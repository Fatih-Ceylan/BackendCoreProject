using GCrm.Application.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GCrm.Application
{
    public static class ServiceRegistration
    {
        public static void AddGCrmApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}