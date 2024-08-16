using BaseProject.Application.Abstractions.Services.Definitions;
using BaseProject.Application.Abstractions.Services.Identity;
using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.Repositories.ReadRepository.Definitions.Files;
using BaseProject.Application.Repositories.ReadRepository.Identity;
using BaseProject.Application.Repositories.WriteRepository.Definitions;
using BaseProject.Application.Repositories.WriteRepository.Definitions.Files;
using BaseProject.Application.Repositories.WriteRepository.Identity;
using BaseProject.Domain.Entities.Identity;
using BaseProject.Persistence.Contexts;
using BaseProject.Persistence.Repositories.ReadRepository.Definitions;
using BaseProject.Persistence.Repositories.ReadRepository.Definitions.Files;
using BaseProject.Persistence.Repositories.ReadRepository.Identity;
using BaseProject.Persistence.Repositories.WriteRepository.Definitions;
using BaseProject.Persistence.Repositories.WriteRepository.Definitions.Files;
using BaseProject.Persistence.Repositories.WriteRepository.Identity;
using BaseProject.Persistence.Services.Definitions;
using BaseProject.Persistence.Services.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProject.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddBaseProjectPersistenceServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddDbContext<BaseProjectDbContext>();
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                //TODO bu alan kurallandırılacak.
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;

            }).AddEntityFrameworkStores<BaseProjectDbContext>().AddDefaultTokenProviders();

            #region AppUser
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAppUserFileReadRepository, AppUserFileReadRepository>();
            services.AddScoped<IAppUserFileWriteRepository, AppUserFileWriteRepository>();
            #endregion

            #region Definitions
            services.AddScoped<ICompanyReadRepository, CompanyReadRepository>();
            services.AddScoped<ICompanyWriteRepository, CompanyWriteRepository>();
            services.AddScoped<IBranchReadRepository, BranchReadRepository>();
            services.AddScoped<IBranchWriteRepository, BranchWriteRepository>();
            services.AddScoped<IDepartmentReadRepository, DepartmentReadRepository>();
            services.AddScoped<IDepartmentWriteRepository, DepartmentWriteRepository>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IMailCredentialReadRepository, MailCredentialReadRepository>();
            services.AddScoped<IMailCredentialWriteRepository, MailCredentialWriteRepository>();
            services.AddScoped<ICompanyLicenseReadRepository, CompanyLicenseReadRepository>();
            services.AddScoped<ICompanyLicenseWriteRepository, CompanyLicenseWriteRepository>();
            services.AddScoped<IAppUserLicenseReadRepository, AppUserLicenseReadRepository>();
            services.AddScoped<IAppUserLicenseWriteRepository, AppUserLicenseWriteRepository>();
            services.AddScoped<ICountryReadRepository, CountryReadRepository>();
            services.AddScoped<ICountryWriteRepository, CountryWriteRepository>();
            services.AddScoped<ICityReadRepository, CityReadRepository>();
            services.AddScoped<ICityWriteRepository, CityWriteRepository>();
            services.AddScoped<IDistrictReadRepository, DistrictReadRepository>();
            services.AddScoped<IDistrictWriteRepository, DistrictWriteRepository>();
            services.AddScoped<IAddressTypeReadRepository, AddressTypeReadRepository>();
            services.AddScoped<IAddressTypeWriteRepository, AddressTypeWriteRepository>();
            services.AddScoped<ICompanyAddressReadRepository, CompanyAddressReadRepository>();
            services.AddScoped<ICompanyAddressWriteRepository, CompanyAddressWriteRepository>();

            #region Files
            services.AddScoped<ICompanyFileReadRepository, CompanyFileReadRepository>();
            services.AddScoped<ICompanyFileWriteRepository, CompanyFileWriteRepository>();
            #endregion

            #region Services
            services.AddScoped<IBranchService, BranchService>();
            #endregion

            #endregion

            #region AppUserAppellation
            services.AddScoped<IAppUserAppellationReadRepository, AppUserAppellationReadRepository>();
            services.AddScoped<IAppUserAppellationWriteRepository, AppUserAppellationWriteRepository>();
            #endregion
        }
    }
}