using BaseProject.Application.Repositories;
using BaseProject.Application.Repositories.WriteRepository.Definitions;
using BaseProject.Persistence.Contexts;
using BaseProject.Persistence.Repositories.WriteRepository.Definitions;
using Card.Application.Abstractions.Services.Order;
using Card.Application.Repositories.ReadRepository;
using Card.Application.Repositories.WriteRepository;
using Card.Persistence.Repositories.ReadRepository;
using Card.Persistence.Repositories.WriteRepository;
using Card.Persistence.Services;
using Platform.Api.Services.BaseProject;
using Platform.Api.Services.Company;


namespace Platform.Api
{
    public static class ServiceRegistration
    {
        public static void AddPlatformApiServices(this IServiceCollection services)
        {
            // Add services to the container.
            services.AddScoped<IBaseProjectService, BaseProjectService>();
            services.AddScoped<IBaseProjectDbContext, BaseProjectDbContext>();
            services.AddScoped<ICompanyWriteRepository, CompanyWriteRepository>();
            services.AddScoped<IBranchWriteRepository, BranchWriteRepository>();
            services.AddScoped<IDepartmentWriteRepository, DepartmentWriteRepository>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IBranchWriteRepository, BranchWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IOrderService,OrderService >();
            services.AddDbContext<BaseProjectDbContext>();
        }
    }
}
