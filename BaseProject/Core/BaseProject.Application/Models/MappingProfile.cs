using AutoMapper;
using BaseProject.Application.DTOs.Identity.AppUser;
using BaseProject.Application.DTOs.Identity.Auth;
using BaseProject.Application.Features.Commands.Definitions.Branch.Create;
using BaseProject.Application.Features.Commands.Definitions.Branch.Update;
using BaseProject.Application.Features.Commands.Definitions.Company.Create;
using BaseProject.Application.Features.Commands.Definitions.Company.Update;
using BaseProject.Application.Features.Commands.Definitions.CompanyAddress.Create;
using BaseProject.Application.Features.Commands.Definitions.CompanyAddress.Update;
using BaseProject.Application.Features.Commands.Definitions.Department.Create;
using BaseProject.Application.Features.Commands.Definitions.Department.Update;
using BaseProject.Application.Features.Commands.Definitions.MailCredential.Create;
using BaseProject.Application.Features.Commands.Definitions.MailCredential.Update;
using BaseProject.Application.Features.Commands.Identity.AppUser.Create;
using BaseProject.Application.Features.Commands.Identity.AppUser.CreateFromPlatform;
using BaseProject.Application.Features.Commands.Identity.AppUser.Login;
using BaseProject.Application.Features.Commands.Identity.AppUser.Update;
using BaseProject.Application.Features.Commands.Identity.AppUserAppellation.Create;
using BaseProject.Application.Features.Queries.Definitions.Company.GetById;
using BaseProject.Application.Features.Queries.Definitions.Department.GetById;
using BaseProject.Application.VMs.Definitions.AppUser;
using BaseProject.Application.VMs.Definitions.Branch;
using BaseProject.Application.VMs.Definitions.CompanyAddress;
using BaseProject.Application.VMs.Definitions.CompanyLicense;
using BaseProject.Domain.Entities.Definitions;
using BaseProject.Domain.Entities.Identity;
using Utilities.Core.UtilityApplication.DTOs.Identity.Auth.Login;
using Utilities.Core.UtilityApplication.DTOs.Mail;

namespace BaseProject.Application.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Company
            CreateMap<Company, GetByIdCompanyResponse>().ReverseMap();
            CreateMap<CreateCompanyRequest, Company>().ReverseMap();
            CreateMap<CreateCompanyResponse, Company>().ReverseMap();
            CreateMap<UpdateCompanyRequest, Company>().ReverseMap();
            CreateMap<Company, UpdateCompanyResponse>().ReverseMap();
            #endregion

            #region Branch
            CreateMap<CreateBranchRequest, Branch>().ReverseMap();
            CreateMap<Branch, BranchVM>().ReverseMap();
            CreateMap<Branch, CreateBranchResponse>().ReverseMap();
            CreateMap<UpdateBranchRequest, Branch>().ReverseMap();
            CreateMap<Branch, UpdateBranchResponse>().ReverseMap();
            #endregion

            #region Department
            CreateMap<Department, GetByIdDepartmentResponse>().ReverseMap();
            CreateMap<CreateDepartmentRequest, Department>().ReverseMap();
            CreateMap<CreateDepartmentResponse, Department>().ReverseMap();
            CreateMap<UpdateDepartmentRequest, Department>().ReverseMap();
            CreateMap<Department, UpdateDepartmentResponse>().ReverseMap();
            #endregion

            #region AppUser
            CreateMap<CreateAppUserRequest, CreateUserRequestDTO>().ReverseMap();
            CreateMap<AppUser, CreateUserResponseDTO>().ReverseMap();
            CreateMap<CreateAppUserResponse, CreateUserResponseDTO>().ReverseMap();
            CreateMap<CreateAppUserFromPlatformRequest, CreateUserRequestDTO>().ReverseMap();
            CreateMap<CreateAppUserFromPlatformResponse, CreateUserResponseDTO>().ReverseMap();
            CreateMap<UpdateUserRequestDTO, UpdateAppUserRequest>().ReverseMap();
            CreateMap<UpdateUserResponseDTO, AppUser>().ReverseMap();
            CreateMap<UpdateUserResponseDTO, UpdateAppUserResponse>().ReverseMap();
            CreateMap<LoginAppUserRequest, LoginRequestDTO>().ReverseMap();
            CreateMap<LoginAppUserResponse, LoginResponseDTO>().ReverseMap();
            CreateMap<AppUserVM,UserDTO>().ReverseMap();

            #endregion
            #region MailCredantial
            CreateMap<CreateMailCredentialRequest, MailCredential>().ReverseMap();
            CreateMap<MailCredential, CreateMailCredentialResponse>().ReverseMap();
            CreateMap<UpdateMailCredentialRequest, MailCredential>().ReverseMap();
            CreateMap<MailCredential, UpdateMailCredentialResponse>().ReverseMap();
            CreateMap<MailCredential, MailCredentialDTO>().ReverseMap();
            #endregion

            #region CompanyLicense
            CreateMap<CompanyLicense, CompanyLicenseCreateVM>().ReverseMap();
            #endregion

            #region CompanyAddress

            CreateMap<CreateCompanyAddressRequest, CompanyAddress>().ReverseMap();
            CreateMap<CreateCompanyAddressResponse, CompanyAddress>().ReverseMap();
            CreateMap<UpdateCompanyAddressRequest, CompanyAddress>().ReverseMap();
            CreateMap<CompanyAddress, UpdateCompanyAddressResponse>().ReverseMap();
            CreateMap<CompanyAddress, CompanyAddressCreateVM>().ReverseMap();
            #endregion

            #region AppUserAppellation
            //CreateMap<CreateAppUserAppellationRequest, AppUserAppellation>().ReverseMap();
            //CreateMap<CreateAppUserAppellationResponse, CreateAppUserAppellationDTO>().ReverseMap();
            CreateMap<AppUserAppellation, CreateAppUserAppellationRequest>().ReverseMap();
            CreateMap<AppUserAppellation, CreateAppUserAppellationResponse>().ReverseMap();
            #endregion
        }
    }
}