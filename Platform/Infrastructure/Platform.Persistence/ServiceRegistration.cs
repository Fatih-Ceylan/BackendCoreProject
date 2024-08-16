using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Platform.Application.Abstractions.Services.Identity;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.Repositories.ReadRepository.Definitions.Files;
using Platform.Application.Repositories.WriteRepository.Definitions;
using Platform.Application.Repositories.WriteRepository.Definitions.Files;
using Platform.Domain.Entities.Identity;
using Platform.Persistence.Contexts;
using Platform.Persistence.Repositories.ReadRepository.Definitions;
using Platform.Persistence.Repositories.ReadRepository.Definitions.Files;
using Platform.Persistence.Repositories.WriteRepository.Definitions;
using Platform.Persistence.Repositories.WriteRepository.Definitions.Files;
using Platform.Persistence.Services.Identity;

namespace Platform.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPlatformPersistenceServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddDbContext<PlatformDbContext>();
            services.AddIdentity<AppUser, AppRole>(options =>
                 {
                     //TODO: bu alan kurallandırılacak.
                     options.Password.RequiredLength = 3;
                     options.Password.RequireNonAlphanumeric = false;
                     options.Password.RequireDigit = false;
                     options.Password.RequireLowercase = false;
                     options.Password.RequireUppercase = false;
                 }).AddEntityFrameworkStores<PlatformDbContext>().AddDefaultTokenProviders();

            #region Definitions

            #region AppUSer
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IAuthService, AuthService>();
            #endregion

            #region Company
            services.AddScoped<ICompanyReadRepository, CompanyReadRepository>();
            services.AddScoped<ICompanyWriteRepository, CompanyWriteRepository>();
            #endregion

            #region Licenses
            services.AddScoped<ILicenseReadRepository, LicenseReadRepository>();
            services.AddScoped<ILicenseWriteRepository, LicenseWriteRepository>();
            #endregion

            #region LicenseType
            services.AddScoped<ILicenseTypeReadRepository, LicenseTypeReadRepository>();
            services.AddScoped<ILicenseTypeWriteRepository, LicenseTypeWriteRepository>();
            #endregion

            #region GModule
            services.AddScoped<IGModuleReadRepository, GModuleReadRepository>();
            services.AddScoped<IGModuleWriteRepository, GModuleWriteRepository>();
            #endregion

            #region GModuleLicenseTypePrice
            services.AddScoped<IGModuleLicenseTypePriceReadRepository, GModuleLicenseTypePriceReadRepository>();
            services.AddScoped<IGModuleLicenseTypePriceWriteRepository, GModuleLicenseTypePriceWriteRepository>();
            #endregion

            #region Files
            services.AddScoped<ICompanyFileReadRepository, CompanyFileReadRepository>();
            services.AddScoped<ICompanyFileWriteRepository, CompanyFileWriteRepository>();
            services.AddScoped<IGModuleFileReadRepository, GModuleFileReadRepository>();
            services.AddScoped<IGModuleFileWriteRepository, GModuleFileWriteRepository>();
            #endregion

            #region SpecialOffer
            services.AddScoped<ISpecialOfferReadRepository, SpecialOfferReadRepository>();
            services.AddScoped<ISpecialOfferWriteRepository, SpecialOfferWriteRepository>();
            #endregion

            #region LicenseDetail
            services.AddScoped<ILicenseDetailReadRepository, LicenseDetailReadRepository>();
            services.AddScoped<ILicenseDetailWriteRepository, LicenseDetailWriteRepository>();
            #endregion

            #region Order
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            #endregion

            #region OrderDetail
            services.AddScoped<IOrderDetailReadRepository, OrderDetailReadRepository>();
            services.AddScoped<IOrderDetailWriteRepository, OrderDetailWriteRepository>();
            #endregion

            #endregion
        }
    }
}