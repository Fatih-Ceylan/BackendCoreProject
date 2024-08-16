using GCharge.Application.Abstractions.Token;
using GCharge.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace GCharge.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddGChargeInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}