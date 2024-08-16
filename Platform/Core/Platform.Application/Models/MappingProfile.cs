using AutoMapper;
using Platform.Application.DTOs.Definitions.Order;
using Platform.Application.DTOs.Identity.AppUser;
using Platform.Application.DTOs.Identity.Auth;
using Platform.Application.Features.Commands.Definitions.Company.Create;
using Platform.Application.Features.Commands.Definitions.Company.Update;
using Platform.Application.Features.Commands.Definitions.GModule.Create;
using Platform.Application.Features.Commands.Definitions.GModule.Update;
using Platform.Application.Features.Commands.Definitions.GModuleLicenseTypePrice.Create;
using Platform.Application.Features.Commands.Definitions.GModuleLicenseTypePrice.Update;
using Platform.Application.Features.Commands.Definitions.License.Create;
using Platform.Application.Features.Commands.Definitions.License.Update;
using Platform.Application.Features.Commands.Definitions.LicenseType.Create;
using Platform.Application.Features.Commands.Definitions.LicenseType.Update;
using Platform.Application.Features.Commands.Definitions.SpecialOffer.Create;
using Platform.Application.Features.Commands.Definitions.SpecialOffer.Update;
using Platform.Application.Features.Commands.Identity.AppUser.Create;
using Platform.Application.Features.Commands.Identity.AppUser.Login;
using Platform.Application.Features.Commands.Identity.AppUser.Update;
using Platform.Application.Features.Queries.Definitions.Company.GetByUrlPath;
using Platform.Application.VMs.Definitions.GModule;
using Platform.Application.VMs.Definitions.GModuleLicenseTypePrice;
using Platform.Application.VMs.Definitions.License;
using Platform.Application.VMs.Definitions.LicenseDetail;
using Platform.Application.VMs.Definitions.OrderDetail;
using Platform.Domain.Entities.Definitions;
using Utilities.Core.UtilityApplication.DTOs.Identity.Auth.Login;

namespace Platform.Application.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Company
            CreateMap<CreateCompanyRequest, Company>().ReverseMap();
            CreateMap<CreateCompanyResponse, Company>().ReverseMap();
            CreateMap<UpdateCompanyRequest, Company>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Company, UpdateCompanyResponse>();
            CreateMap<Company, GetByUrlPathCompanyResponse>().ReverseMap();
            #endregion

            #region AppUser
            CreateMap<CreateAppUserRequest, CreateUserRequestDTO>().ReverseMap();
            CreateMap<CreateAppUserResponse, CreateUserResponseDTO>().ReverseMap();
            CreateMap<UpdateUserRequestDTO, UpdateAppUserRequest>().ReverseMap();
            CreateMap<UpdateUserResponseDTO, UpdateAppUserResponse>().ReverseMap();
            CreateMap<LoginAppUserRequest, LoginRequestDTO>().ReverseMap();
            CreateMap<LoginAppUserResponse, LoginResponseDTO>().ReverseMap();
            #endregion

            #region License
            CreateMap<CreateLicenseRequest, License>().ReverseMap();
            CreateMap<CreateLicenseResponse, License>().ReverseMap();
            CreateMap<UpdateLicenseRequest, License>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<License, UpdateLicenseResponse>().ReverseMap();
            CreateMap<License, CreateLicenseResponseVM>().ReverseMap();
            #endregion

            #region LicenseDetail
            CreateMap<CreateLicenseDetailVM, LicenseDetail>().ReverseMap();
            #endregion

            #region LicenseType
            CreateMap<CreateLicenseTypeRequest, LicenseType>().ReverseMap();
            CreateMap<CreateLicenseTypeResponse, LicenseType>().ReverseMap();
            CreateMap<UpdateLicenseTypeRequest, LicenseType>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<LicenseType, UpdateLicenseTypeResponse>().ReverseMap();
            #endregion

            #region GModule
            CreateMap<CreateGModuleResponse, GModule>().ReverseMap();
            CreateMap<GModule, UpdateGModuleResponse>().ReverseMap();
            CreateMap<UpdateGModuleRequest, GModule>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<GModuleVM, GModule>().ReverseMap();
            #endregion

            #region GModuleLicenseTypePrice
            CreateMap<GModuleLicenseTypePriceCreateVM, GModuleLicenseTypePrice>().ReverseMap();
            CreateMap<GModuleLicenseTypePriceUpdateVM, GModuleLicenseTypePrice>().ReverseMap();
            CreateMap<CreateGModuleLicenseTypePriceRequest, GModuleLicenseTypePrice>().ReverseMap();
            CreateMap<CreateGModuleLicenseTypePriceResponse, GModuleLicenseTypePrice>().ReverseMap();
            CreateMap<GModuleLicenseTypePrice, UpdateGModuleLicenseTypePriceResponse>().ReverseMap();
            CreateMap<UpdateGModuleLicenseTypePriceRequest, GModuleLicenseTypePrice>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            #endregion

            #region SpecialOffer

            CreateMap<CreateSpecialOfferRequest, SpecialOffer>().ReverseMap();
            CreateMap<CreateSpecialOfferResponse, SpecialOffer>().ReverseMap();
            CreateMap<UpdateSpecialOfferRequest, SpecialOffer>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<SpecialOffer, UpdateSpecialOfferResponse>().ReverseMap();

            #endregion

            #region OrderDetail
            CreateMap<OrderDetailCreateVM, OrderDetail>().ReverseMap();
            //CreateMap<CreateOrderDetailResponseDTO, OrderDetail>().ReverseMap();
            //CreateMap<UpdateCompanyRequest, Company>().ForAllMembers(opts =>
            //{
            //    opts.Condition((src, dest, srcMember) => srcMember != null);
            //});
            //CreateMap<Company, UpdateCompanyResponse>();
            //CreateMap<Company, GetByUrlPathCompanyResponse>().ReverseMap();
            #endregion

            #region Order
            CreateMap<CreateOrderRequestDTO, Order>().ReverseMap();
            CreateMap<CreateOrderResponseDTO, Order>().ReverseMap();
            //CreateMap<CreateOrderDetailResponseDTO, OrderDetail>().ReverseMap();
            //CreateMap<UpdateCompanyRequest, Company>().ForAllMembers(opts =>
            //{
            //    opts.Condition((src, dest, srcMember) => srcMember != null);
            //});
            //CreateMap<Company, UpdateCompanyResponse>();
            //CreateMap<Company, GetByUrlPathCompanyResponse>().ReverseMap();
            #endregion
        }
    }
}