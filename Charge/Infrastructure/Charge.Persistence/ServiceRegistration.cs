using GCharge.Application.Abstractions.Identity;
using GCharge.Application.Repositories.ReadRepository.Definitions;
using GCharge.Application.Repositories.WriteRepository.Definitions;
using GCharge.Domain.Entities.Identity;
using GCharge.Persistence.Contexts;
using GCharge.Persistence.Repositories.ReadRepository.Definitions;
using GCharge.Persistence.Repositories.WriteRepository.Definitions;
using GCharge.Persistence.Services.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace GCharge.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddGChargePersistenceServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddDbContext<GChargeDbContext>();
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                //TODO bu alan kurallandırılacak.
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;

            }).AddEntityFrameworkStores<GChargeDbContext>().AddDefaultTokenProviders();

            #region Definitions
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IChargePointReadRepository, ChargePointReadRepository>();

            services.AddScoped<IConnectorStatusReadRepository, ConnectorStatusReadRepository>();

            services.AddScoped<IChargeTagReadRepository, ChargeTagReadRepository>();
            services.AddScoped<IChargeTagWriteRepository, ChargeTagWriteRepository>();

            services.AddScoped<IUserChargeTagReadRepository, UserChargeTagReadRepository>();
            services.AddScoped<IUserChargeTagWriteRepository, UserChargeTagWriteRepository>();


            services.AddScoped<ITransactionReadRepository, TransactionReadRepository>();

            services.AddScoped<ITransactionDetailReadRepository, TransactionDetailReadRepository>();

            services.AddScoped<IElectricitySalesPriceReadRepository, ElectricitySalesPriceReadRepository>();
            services.AddScoped<IElectricitySalesPriceWriteRepository, ElectricitySalesPriceWriteRepository>();

            services.AddScoped<IUserTransactionReadRepository, UserTransactionReadRepository>();
            #endregion
        }
    }
}