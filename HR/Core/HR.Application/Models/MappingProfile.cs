using AutoMapper;
using BaseProject.Domain.Entities.HR.Employment;
using BaseProject.Domain.Entities.HR.Recruitment.Applications;
using BaseProject.Domain.Entities.HR.Recruitment.Jobs;
using HR.Application.Features.Commands.Definitions.Employment.Appellation.Create;
using HR.Application.Features.Commands.Definitions.Employment.Appellation.Update;
using HR.Application.Features.Commands.Definitions.Employment.EducationInfo.Create;
using HR.Application.Features.Commands.Definitions.Employment.EducationInfo.Update;
using HR.Application.Features.Commands.Definitions.Employment.Employee.Create;
using HR.Application.Features.Commands.Definitions.Employment.Employee.Update;
using HR.Application.Features.Commands.Definitions.Employment.Leave.Create;
using HR.Application.Features.Commands.Definitions.Employment.Leave.Update;
using HR.Application.Features.Commands.Definitions.Employment.LeaveType.Create;
using HR.Application.Features.Commands.Definitions.Employment.LeaveType.Update;
using HR.Application.Features.Commands.Definitions.Employment.Payroll.Create;
using HR.Application.Features.Commands.Definitions.Employment.Payroll.Update;
using HR.Application.Features.Commands.Definitions.Recruitment.Applications.JobApplicant.Create;
using HR.Application.Features.Commands.Definitions.Recruitment.Applications.JobApplicant.Update;
using HR.Application.Features.Commands.Definitions.Recruitment.Applications.JobApplication.Create;
using HR.Application.Features.Commands.Definitions.Recruitment.Applications.JobApplication.Update;
using HR.Application.Features.Commands.Definitions.Recruitment.Applications.JobApplicationStatus.Create;
using HR.Application.Features.Commands.Definitions.Recruitment.Jobs.JobAdvert.Create;
using HR.Application.Features.Commands.Definitions.Recruitment.Jobs.JobAdvert.Update;

namespace HR.Application.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Employee
            CreateMap<Employee, CreateEmployeeRequest>().ReverseMap();
            CreateMap<Employee, CreateEmployeeResponse>().ReverseMap();
            CreateMap<UpdateEmployeeRequest, Employee>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Employee, UpdateEmployeeResponse>().ReverseMap();
            #endregion

            #region Appellation
            CreateMap<Appellation, CreateAppellationRequest>().ReverseMap();
            CreateMap<Appellation, CreateAppellationResponse>().ReverseMap();
            CreateMap<UpdateAppellationRequest, Appellation>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Appellation, UpdateAppellationResponse>().ReverseMap();
            #endregion

            #region Leave
            CreateMap<Leave, CreateLeaveRequest>().ReverseMap();
            CreateMap<Leave, CreateLeaveResponse>().ReverseMap();
            CreateMap<UpdateLeaveRequest, Leave>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Leave, UpdateLeaveResponse>().ReverseMap();
            #endregion

            #region LeaveType
            CreateMap<LeaveType, CreateLeaveTypeRequest>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeResponse>().ReverseMap();
            CreateMap<UpdateLeaveTypeRequest, LeaveType>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<LeaveType, UpdateLeaveTypeResponse>().ReverseMap();
            #endregion

            #region EducationInfo
            CreateMap<EducationInfo, CreateEducationInfoRequest>().ReverseMap();
            CreateMap<EducationInfo, CreateEducationInfoResponse>().ReverseMap();
            CreateMap<UpdateEducationInfoRequest, EducationInfo>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<EducationInfo, UpdateEducationInfoResponse>().ReverseMap();
            #endregion

            #region Payroll
            CreateMap<Payroll, CreatePayrollRequest>().ReverseMap();
            CreateMap<Payroll, CreatePayrollResponse>().ReverseMap();
            CreateMap<UpdatePayrollRequest, Payroll>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Payroll, UpdatePayrollResponse>().ReverseMap();
            #endregion

            #region Recruitment
            //CreateMap<Job, CreateCustomerRequest>().ReverseMap();
            //CreateMap<Customer, CreateCustomerResponse>().ReverseMap();
            //CreateMap<UpdateCustomerRequest, Customer>().ForAllMembers(opts =>
            //{
            //    opts.Condition((src, dest, srcMember) => srcMember != null);
            //});
            //CreateMap<Customer, UpdateCustomerResponse>().ReverseMap();
            #endregion

            #region JobAdvert
            CreateMap<JobAdvert, CreateJobAdvertRequest>().ReverseMap();
            CreateMap<JobAdvert, CreateJobAdvertResponse>().ReverseMap();
            CreateMap<UpdateJobAdvertRequest, JobAdvert>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<JobAdvert, UpdateJobAdvertResponse>().ReverseMap();
            #endregion

            #region JobApplicant
            CreateMap<JobApplicant, CreateJobApplicantRequest>().ReverseMap();
            CreateMap<JobApplicant, CreateJobApplicantResponse>().ReverseMap();
            CreateMap<UpdateJobApplicantRequest, JobApplicant>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<JobApplicant, UpdateJobApplicantResponse>().ReverseMap();

            #endregion

            #region JobApplication
            CreateMap<JobApplication, CreateJobApplicationRequest>().ReverseMap();
            CreateMap<JobApplication, CreateJobApplicationResponse>().ReverseMap();
            CreateMap<UpdateJobApplicationRequest, JobApplication>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<JobApplication, UpdateJobApplicationResponse>().ReverseMap();

            #endregion

            #region JobApplicationStatus
            CreateMap<JobApplicationStatus, CreateJobApplicationStatusRequest>().ReverseMap();
            CreateMap<JobApplicationStatus, CreateJobApplicationStatusResponse>().ReverseMap();
            //CreateMap<UpdateJobApplicationStatusRequest, JobApplicationStatus>().ForAllMembers(opts =>
            //{
            //    opts.Condition((src, dest, srcMember) => srcMember != null);
            //});
            //CreateMap<JobApplicationStatus, UpdateJobApplicationStatusResponse>().ReverseMap();

            #endregion
        }
    }
}
