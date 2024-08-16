using GCharge.Application.Abstractions.Hubs;
using GCharge.SignalR.HubServices;
using Microsoft.Extensions.DependencyInjection;

namespace GCharge.SignalR
{
    public static class ServiceRegistration
    {
        public static void AddGChargeSignalRServices(this IServiceCollection services)
        {
            services.AddTransient<ITransactionHubService, TransactionHubService>();
            services.AddSignalR();
        }
    }
}