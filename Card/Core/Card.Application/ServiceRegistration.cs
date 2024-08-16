using Card.Application.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using P = Platform.Application.Models;

namespace Card.Application
{
    public static class ServiceRegistration
    {
        public static void AddCardApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddAutoMapper(typeof(P.MappingProfile));
        }
    }
}
