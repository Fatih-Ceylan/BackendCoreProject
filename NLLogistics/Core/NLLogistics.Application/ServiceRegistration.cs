using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NLLogistics.Application.Models;

namespace NLLogistics.Application
{
    public static class ServiceRegistration
    {
        public static void AddNLLogisticsApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}