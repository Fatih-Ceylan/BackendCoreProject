using BaseProject.Persistence.Contexts;
using GControl.Application.Abstractions.Mail;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using GControl.Persistence.Mail;
using GControl.Persistence.Repositories.ReadRepository;
using GControl.Persistence.Repositories.ReadRepository.Files;
using GControl.Persistence.Repositories.WriteRepository;
using GControl.Persistence.Repositories.WriteRepository.Files;
using Microsoft.Extensions.DependencyInjection;

namespace GControl.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddGControlPersistenceServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddDbContext<BaseProjectDbContext>();

            #region EmployeeLabel

            services.AddScoped<IEmployeeLabelReadRepository, EmployeeLabelReadRepository>();
            services.AddScoped<IEmployeeLabelWriteRepository, EmployeeLabelWriteRepository>();
            #endregion

            #region EmployeeType

            services.AddScoped<IEmployeeTypeReadRepository, EmployeeTypeReadRepository>();
            services.AddScoped<IEmployeeTypeWriteRepository, EmployeeTypeWriteRepository>();
            #endregion

            #region ApplicationSetting

            services.AddScoped<IApplicationSettingReadRepository, ApplicationSettingReadRepository>();
            services.AddScoped<IApplicationSettingWriteRepository, ApplicationSettingWriteRepository>();
            #endregion

            #region ShiftManagement

            services.AddScoped<IShiftManagementReadRepository, ShiftManagementReadRepository>();
            services.AddScoped<IShiftManagementWriteRepository, ShiftManagementWriteRepository>();
            #endregion

            #region Location

            services.AddScoped<ILocationReadRepository, LocationReadRepository>();
            services.AddScoped<ILocationWriteRepository, LocationWriteRepository>();
            #endregion

            #region Employee

            services.AddScoped<IEmployeeReadRepository, EmployeeReadRepository>();
            services.AddScoped<IEmployeeWriteRepository, EmployeeWriteRepository>();
            #endregion

            #region EntryExitManagement

            services.AddScoped<IEntryExitManagementReadRepository, EntryExitManagementReadRepository>();
            services.AddScoped<IEntryExitManagementWriteRepository, EntryExitManagementWriteRepository>();
            #endregion

            #region Department

            services.AddScoped<IDepartmentReadRepository, DepartmentReadRepository>();
            services.AddScoped<IDepartmentWriteRepository, DepartmentWriteRepository>();
            #endregion
            #region Files
            services.AddScoped<IEmployeeFileReadRepository, EmployeeFileReadRepository>();
            services.AddScoped<IEmployeeFileWriteRepository, EmployeeFileWriteRepository>();
            #endregion
            #region Mail
            services.AddScoped<IMailService, MailService>();
            #endregion

            #region PasswordRemake
            services.AddScoped<IPasswordRemakeReadRepository, PasswordRemakeReadRepository>();
            services.AddScoped<IPasswordRemakeWriteRepository, PasswordRemakeWriteRepository>();
            #endregion

            #region UserMainInfo
            services.AddScoped<IUserMainInfoReadRepository, UserMainInfoReadRepository>();
            services.AddScoped<IUserMainInfoWriteRepository, UserMainInfoWriteRepository>();
            #endregion

            #region Announcement

            services.AddScoped<IAnnouncementReadRepository, AnnouncementReadRepository>();
            services.AddScoped<IAnnouncementWriteRepository, AnnouncementWriteRepository>();
            #endregion
        }
    }
}