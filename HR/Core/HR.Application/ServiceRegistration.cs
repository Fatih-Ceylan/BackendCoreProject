using HR.Application.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HR.Application
{
    public static class ServiceRegistration
    {
        public static void AddHRApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
