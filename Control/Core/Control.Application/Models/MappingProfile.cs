using AutoMapper;
using BaseProject.Domain.Entities.GControl.Definitions;
using BaseProject.Domain.Entities.GControl.Definitions.Files;
using GControl.Application.Features.Commands.Definitions.Announcement.Create;
using GControl.Application.Features.Commands.Definitions.Announcement.Update;
using GControl.Application.Features.Commands.Definitions.ApplicationSetting.Create;
using GControl.Application.Features.Commands.Definitions.ApplicationSetting.Update;
using GControl.Application.Features.Commands.Definitions.Department.Create;
using GControl.Application.Features.Commands.Definitions.Department.Update;
using GControl.Application.Features.Commands.Definitions.Employee.Create;
using GControl.Application.Features.Commands.Definitions.Employee.EmployeeCredentials;
using GControl.Application.Features.Commands.Definitions.Employee.Update;
using GControl.Application.Features.Commands.Definitions.EmployeeFile.Create;
using GControl.Application.Features.Commands.Definitions.EmployeeLabel.Create;
using GControl.Application.Features.Commands.Definitions.EmployeeLabel.Update;
using GControl.Application.Features.Commands.Definitions.EmployeeType.Create;
using GControl.Application.Features.Commands.Definitions.EmployeeType.Update;
using GControl.Application.Features.Commands.Definitions.EntryExitManagement.Create;
using GControl.Application.Features.Commands.Definitions.EntryExitManagement.ToggleEntryExitRecord;
using GControl.Application.Features.Commands.Definitions.EntryExitManagement.Update;
using GControl.Application.Features.Commands.Definitions.Location.Create;
using GControl.Application.Features.Commands.Definitions.Location.Update;
using GControl.Application.Features.Commands.Definitions.ShiftManagement.Create;
using GControl.Application.Features.Commands.Definitions.ShiftManagement.Update;
using GControl.Application.Features.Commands.Definitions.UserMainInfo.Create;
using GControl.Application.Features.Commands.Identity.Employee.ChangePassword;
using GControl.Application.Features.Commands.Identity.Employee.ForgotPassword;
using GControl.Application.Features.Commands.Identity.Employee.Login;
using GControl.Application.Features.Commands.Identity.Employee.SendPasswordWithMail;
using GControl.Application.VMs.Definitions;

namespace GControl.Application.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region EmployeeLabel
            CreateMap<EmployeeLabel, CreateEmployeeLabelRequest>().ReverseMap();
            CreateMap<EmployeeLabel, CreateEmployeeLabelResponse>().ReverseMap();
            CreateMap<UpdateEmployeeLabelRequest, EmployeeLabel>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<EmployeeLabel, UpdateEmployeeLabelResponse>().ReverseMap();
            #endregion

            #region EmployeeType
            CreateMap<EmployeeType, CreateEmployeeTypeRequest>().ReverseMap();
            CreateMap<EmployeeType, CreateEmployeeTypeResponse>().ReverseMap();
            CreateMap<UpdateEmployeeTypeRequest, EmployeeType>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<EmployeeType, UpdateEmployeeTypeResponse>().ReverseMap();
            #endregion

            #region EmployeeType
            CreateMap<ApplicationSetting, CreateApplicationSettingRequest>().ReverseMap();
            CreateMap<ApplicationSetting, CreateApplicationSettingResponse>().ReverseMap();
            CreateMap<UpdateApplicationSettingRequest, ApplicationSetting>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<ApplicationSetting, UpdateApplicationSettingResponse>().ReverseMap();
            #endregion

            #region ShiftManagement
            CreateMap<ShiftManagement, CreateShiftManagementRequest>().ReverseMap();
            CreateMap<ShiftManagement, CreateShiftManagementResponse>().ReverseMap();
            CreateMap<UpdateShiftManagementRequest, ShiftManagement>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<ShiftManagement, UpdateShiftManagementResponse>().ReverseMap();
            #endregion

            #region Location
            CreateMap<Location, CreateLocationRequest>().ReverseMap();
            CreateMap<Location, CreateLocationResponse>().ReverseMap();
            CreateMap<UpdateLocationRequest, Location>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Location, UpdateLocationResponse>().ReverseMap();
            #endregion

            #region Employee
            CreateMap<Employee, CreateEmployeeRequest>().ReverseMap();
            CreateMap<Employee, CreateEmployeeResponse>().ReverseMap();
            CreateMap<Employee, ForgotPasswordRequest>().ReverseMap();
            CreateMap<Employee, ChangePasswordRequest>().ReverseMap();
            CreateMap<Employee, LoginEmployeeRequest>().ReverseMap();
            CreateMap<Employee, EmployeeVM>().ReverseMap();
            CreateMap<UpdateEmployeeRequest, Employee>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Employee, UpdateEmployeeResponse>().ReverseMap();
            CreateMap<EmployeeVM, EmployeeNewBaseVM>().ReverseMap();
            CreateMap<Employee, EmployeeCredentialsRequest>().ReverseMap();
            CreateMap<Employee, EmployeeCredentialsResponse>().ReverseMap();
            #endregion

            #region EntryExitManagement
            CreateMap<EntryExitManagement, CreateEntryExitManagementRequest>().ReverseMap();
            CreateMap<EntryExitManagement, CreateEntryExitManagementResponse>().ReverseMap();
            CreateMap<EntryExitManagement, EntryExitManagementVM>().ReverseMap();
            CreateMap<UpdateEntryExitManagementRequest, EntryExitManagement>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<EntryExitManagement, UpdateEntryExitManagementResponse>().ReverseMap();
            #endregion

            #region Department
            CreateMap<Department, CreateDepartmentRequest>().ReverseMap();
            CreateMap<Department, CreateDepartmentResponse>().ReverseMap();
            CreateMap<UpdateDepartmentRequest, Department>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Department, UpdateDepartmentResponse>().ReverseMap();
            #endregion
            #region EmployeeFile

            CreateMap<EmployeeFile, CreateEmployeeFileRequest>().ReverseMap();
            CreateMap<EmployeeFile, CreateEmployeeFileResponse>().ReverseMap();

            #endregion
            #region ForgotPasswordSendMail

            CreateMap<PasswordRemake, SendPasswordWithMailRequest>().ReverseMap();
            CreateMap<PasswordRemake, SendPasswordWithMailResponse>().ReverseMap();

            #endregion
            #region ForgotPassword

            CreateMap<PasswordRemake, ForgotPasswordRequest>().ReverseMap();
            CreateMap<PasswordRemake, ForgotPasswordResponse>().ReverseMap();

            #endregion

            #region UserMainInfo

            CreateMap<UserMainInfo, CreateUserMainInfoRequest>().ReverseMap();
            CreateMap<UserMainInfo, CreateUserMainInfoResponse>().ReverseMap();

            #endregion

            #region Announcement

            CreateMap<Announcement, CreateAnnouncementRequest>().ReverseMap();
            CreateMap<Announcement, CreateAnnouncementResponse>().ReverseMap();
            CreateMap<UpdateAnnouncementRequest, Announcement>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Announcement, UpdateAnnouncementResponse>().ReverseMap();
            CreateMap<Department, BaseProject.Domain.Entities.GControl.Definitions. DepartmentVM>().ReverseMap();
            #endregion

            #region ToggleEntryExitRecord
            CreateMap<EntryExitManagement, ToggleEntryExitRecordRequest>().ReverseMap();
            CreateMap<EntryExitManagement, ToggleEntryExitRecordResponse>().ReverseMap();
            CreateMap<EntryExitManagement, EntryExitManagementVM>().ReverseMap();
            #endregion
        }
    }
}
