using Microsoft.Extensions.DependencyInjection;
using NLLogistics.Application.Repositories.ReadRepositories.Definitions;
using NLLogistics.Application.Repositories.WriteRepositories.Definitions;
using NLLogistics.Persistence.Repositories.ReadRepositories.Definitions;
using NLLogistics.Persistence.Repositories.WriteRepositories.Definitions;

namespace NLLogistics.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddNLLogisticsPersistenceServices(this IServiceCollection services)
        {
            #region Definitions
            
            services.AddScoped<IAirlineReadRepository, AirlineReadRepository>();
            services.AddScoped<IAirlineWriteRepository, AirlineWriteRepository>();
            services.AddScoped<IAirportReadRepository, AirportReadRepository>();
            services.AddScoped<IAirportWriteRepository, AirportWriteRepository>();
            services.AddScoped<IPortReadRepository, PortReadRepository>();
            services.AddScoped<IPortWriteRepository, PortWriteRepository>();
            services.AddScoped<IVesselReadRepository, VesselReadRepository>();
            services.AddScoped<IVesselWriteRepository, VesselWriteRepository>();
            services.AddScoped<IVoyageReadRepository, VoyageReadRepository>();
            services.AddScoped<IVoyageWriteRepository, VoyageWriteRepository>();

            #endregion
        }
    }
}