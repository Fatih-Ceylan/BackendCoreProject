using GCharge.Application.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GCharge.Application
{
    public static class ServiceRegistration
    {
        public static void AddGChargeApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
