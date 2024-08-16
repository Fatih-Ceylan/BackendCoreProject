using AutoMapper;
using GCharge.Application.DTOs.Identity.AppUser;
using GCharge.Application.DTOs.Identity.Auth;
using GCharge.Application.Features.Commands.Definitions.ChargeTag.Create;
using GCharge.Application.Features.Commands.Definitions.ElectricitySalesPrice.Create;
using GCharge.Application.Features.Commands.Definitions.ElectricitySalesPrice.Update;
using GCharge.Application.Features.Commands.Definitions.UserChargeTag.Create;
using GCharge.Application.Features.Commands.Identity.AppUser.Create;
using GCharge.Application.Features.Commands.Identity.AppUser.Login;
using GCharge.Application.Features.Commands.Identity.AppUser.Update;
using GCharge.Domain.Entities.Definitions;
using GCharge.Domain.Entities.Identity;
using Utilities.Core.UtilityApplication.DTOs.Identity.Auth.Login;
using Utilities.Core.UtilityApplication.VMs;

namespace GCharge.Application.Models
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            #region AppUser
            CreateMap<CreateAppUserRequest, CreateUserRequestDTO>().ReverseMap();
            CreateMap<AppUser, CreateUserResponseDTO>().ReverseMap();
            CreateMap<CreateAppUserResponse, CreateUserResponseDTO>().ReverseMap();
            CreateMap<UpdateUserRequestDTO, UpdateAppUserRequest>().ReverseMap();
            CreateMap<UpdateUserResponseDTO, AppUser>().ReverseMap();
            CreateMap<UpdateUserResponseDTO, UpdateAppUserResponse>().ReverseMap();
            CreateMap<LoginAppUserRequest, LoginRequestDTO>().ReverseMap();
            CreateMap<LoginAppUserResponse, LoginResponseDTO>().ReverseMap();
            CreateMap<AppUserVM, UserDTO>().ReverseMap();
            #endregion

            #region ChargeTag
            CreateMap<ChargeTag, CreateChargeTagRequest>().ReverseMap();
            CreateMap<ChargeTag, CreateChargeTagResponse>().ReverseMap();
            #endregion

            #region UserChargeTag
            CreateMap<UserChargeTag, CreateUserChargeTagRequest>().ReverseMap();
            CreateMap<UserChargeTag, CreateUserChargeTagResponse>().ReverseMap();
            #endregion

            #region ElectricitySalesPrice
            CreateMap<ElectricitySalesPrice, CreateElectricitySalesPriceRequest>().ReverseMap();
            CreateMap<ElectricitySalesPrice, CreateElectricitySalesPriceResponse>().ReverseMap();
            CreateMap<UpdateElectricitySalesPriceRequest, ElectricitySalesPrice>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<ElectricitySalesPrice, UpdateElectricitySalesPriceResponse>().ReverseMap();
            #endregion
        }
    }
}
