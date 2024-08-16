using Card.Application.Abstractions.Services.Payment;
using Card.Infrastructure.Services.Payment;
using Microsoft.Extensions.DependencyInjection;

namespace Card.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddCardInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IVakifBankVposService, VakifBankVposService>(); 
            services.AddScoped<IVakifBank3dSecureService, VakifBank3dSecureService>();
            services.AddHttpClient<IVakifBank3dSecureService, VakifBank3dSecureService>();
        }
    }
}
