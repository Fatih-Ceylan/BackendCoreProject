using BaseProject.Application.Abstractions.Hubs;
using BaseProject.SignalR.HubServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.SignalR
{
    public static class ServiceRegistration
    {
        public static void AddBaseProjectSignalRServices(this IServiceCollection services)
        {
            services.AddTransient<IUserHubService, UserHubService>();
            services.AddSignalR();
        }
    }
}