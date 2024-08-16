using AutoMapper;
using T = BaseProject.Domain.Entities.Card.Definitions;
using BaseProject.Domain.Entities.Card.Definitions.Files;
using Card.Application.Features.Commands.Definitions.Address.Create;
using Card.Application.Features.Commands.Definitions.Address.Update;
using Card.Application.Features.Commands.Definitions.Card.Create;
using Card.Application.Features.Commands.Definitions.Card.Update;
using Card.Application.Features.Commands.Definitions.Cargo.Create;
using Card.Application.Features.Commands.Definitions.Cargo.Update;
using Card.Application.Features.Commands.Definitions.Field.Create;
using Card.Application.Features.Commands.Definitions.Field.Update;
using Card.Application.Features.Commands.Definitions.Iban.Create;
using Card.Application.Features.Commands.Definitions.Iban.Update;
using Card.Application.Features.Commands.Definitions.Order.Create;
using Card.Application.Features.Commands.Definitions.Order.Update;
using Card.Application.Features.Commands.Definitions.OrderDetail.Create;
using Card.Application.Features.Commands.Definitions.OrderDetail.Update;
using Card.Application.Features.Commands.Definitions.PhoneNumber.Create;
using Card.Application.Features.Commands.Definitions.PhoneNumber.Update;
using Card.Application.Features.Commands.Definitions.SocialMedia.Create;
using Card.Application.Features.Commands.Definitions.SocialMedia.Update;
using Card.Application.Features.Commands.Definitions.SocialMediaUrl.Create;
using Card.Application.Features.Commands.Definitions.SocialMediaUrl.Update;
using Card.Application.Features.Commands.Definitions.Staff.Create;
using Card.Application.Features.Commands.Definitions.Staff.Update;
using Card.Application.Features.Commands.Definitions.StaffContact.Create;
using Card.Application.Features.Commands.Definitions.StaffContact.Update;
using Card.Application.Features.Commands.Definitions.StaffField.Create;
using Card.Application.Features.Commands.Definitions.StaffField.Update;
using Card.Application.Features.Commands.Definitions.StaffField.UpdateWithList;
using Card.Application.Features.Commands.Definitions.StaffFile.Create;
using Card.Application.Features.Commands.Identity.Staff.ChangePassword;
using Card.Application.Features.Commands.Identity.Staff.ForgotPassword;
using Card.Application.Features.Commands.Identity.Staff.ForgotPasswordSendMail;
using Card.Application.Features.Commands.Identity.Staff.Login;
using Card.Application.VMs;
using BaseProject.Domain.Entities.Card.Definitions;
namespace Card.Application.Models
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            #region Staff

            CreateMap<Staff, CreateStaffRequest>().ReverseMap();
            CreateMap<Staff, CreateStaffResponse>().ReverseMap();
            CreateMap<Staff, LoginStaffRequest>().ReverseMap();
            CreateMap<Staff, ChangePasswordRequest>().ReverseMap();
            CreateMap<Staff, ForgotPasswordRequest>().ReverseMap();
            CreateMap<UpdateStaffRequest, Staff>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Staff, UpdateStaffResponse>().ReverseMap();

            #endregion

            #region SocialMedia

            CreateMap<SocialMedia, CreateSocialMediaRequest>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaResponse>().ReverseMap();
            CreateMap<UpdateSocialMediaRequest, SocialMedia>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<SocialMedia, UpdateSocialMediaResponse>().ReverseMap();

            #endregion

            #region SocialMediaUrl

            CreateMap<SocialMediaUrl, CreateSocialMediaUrlRequest>().ReverseMap();
            CreateMap<SocialMediaUrl, CreateSocialMediaUrlResponse>().ReverseMap();
            CreateMap<UpdateSocialMediaUrlRequest, SocialMediaUrl>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<SocialMediaUrl, UpdateSocialMediaUrlResponse>().ReverseMap();

            #endregion

            #region Iban

            CreateMap<Iban, CreateIbanRequest>().ReverseMap();
            CreateMap<Iban, CreateIbanResponse>().ReverseMap();
            CreateMap<UpdateIbanRequest, Iban>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Iban, UpdateIbanResponse>().ReverseMap();

            #endregion

            #region PhoneNumber

            CreateMap<PhoneNumber, CreatePhoneNumberRequest>().ReverseMap();
            CreateMap<PhoneNumber, CreatePhoneNumberResponse>().ReverseMap();
            CreateMap<UpdatePhoneNumberRequest, PhoneNumber>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<PhoneNumber, UpdatePhoneNumberResponse>().ReverseMap();

            #endregion

            #region StaffContact

            CreateMap<StaffContact, CreateStaffContactRequest>().ReverseMap();
            CreateMap<StaffContact, CreateStaffContactResponse>().ReverseMap();
            CreateMap<UpdateStaffContactRequest, StaffContact>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<StaffContact, UpdateStaffContactResponse>().ReverseMap();

            #endregion

            #region StaffField

            CreateMap<StaffField, CreateStaffFieldRequest>().ReverseMap();
            CreateMap<StaffField, CreateStaffFieldResponse>().ReverseMap();
            CreateMap<UpdateStaffFieldRequest, StaffField>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<StaffField, UpdateStaffFieldResponse>().ReverseMap();

            CreateMap<UpdateWithListStaffFieldRequest, StaffField>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<List<StaffField>, UpdateWithListStaffFieldResponse>().ReverseMap();
            CreateMap<UpdateWithListStaffFieldRequest, StaffField>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });

            #endregion

            #region Field

            CreateMap<Field, CreateFieldRequest>().ReverseMap();
            CreateMap<Field, CreateFieldResponse>().ReverseMap();
            CreateMap<UpdateFieldRequest, Field>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Field, UpdateFieldResponse>().ReverseMap();

            #endregion

            #region StaffFile

            CreateMap<StaffFile, CreateStaffFileRequest>().ReverseMap();
            CreateMap<StaffFile, CreateStaffFileResponse>().ReverseMap();

            #endregion

            #region ForgotPasswordSendMail

            CreateMap<PasswordRemake, ForgotPasswordSendMailRequest>().ReverseMap();
            CreateMap<PasswordRemake, ForgotPasswordSendMailResponse>().ReverseMap();

            #endregion

            #region ForgotPassword

            CreateMap<PasswordRemake, ForgotPasswordRequest>().ReverseMap();
            CreateMap<PasswordRemake, ForgotPasswordResponse>().ReverseMap();

            #endregion

            #region Card

            CreateMap<T.Card, CreateCardRequest>().ReverseMap();
            CreateMap<T.Card, CreateCardResponse>().ReverseMap();
            CreateMap<UpdateCardRequest, T.Card>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<T.Card, UpdateCardResponse>().ReverseMap();

            #endregion

            #region Cargo

            CreateMap<Cargo, CreateCargoRequest>().ReverseMap();
            CreateMap<Cargo, CreateCargoResponse>().ReverseMap();
            CreateMap<UpdateCargoRequest, Cargo>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Cargo, UpdateCargoResponse>().ReverseMap();

            #endregion

            #region Order

            CreateMap<Order, CreateOrderRequest>().ReverseMap();
            CreateMap<Order, CreateOrderResponse>().ReverseMap();
            CreateMap<Order, CreateOrderVM>().ReverseMap();
            CreateMap<UpdateOrderRequest, Order>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Order, UpdateOrderResponse>().ReverseMap();

            #endregion

            #region OrderDetail

            CreateMap<OrderDetail, CreateOrderDetailRequest>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailResponse>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailVM>().ReverseMap();
            CreateMap<UpdateOrderDetailRequest, OrderDetail>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<OrderDetail, UpdateOrderDetailResponse>().ReverseMap();

            #endregion

            #region Address

            CreateMap<Address, CreateAddressRequest>().ReverseMap();
            CreateMap<Address, CreateAddressResponse>().ReverseMap();
            CreateMap<Address, CreateAddressVM>().ReverseMap();
            CreateMap<UpdateAddressRequest, Address>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Address, UpdateAddressResponse>().ReverseMap();

            #endregion 
        }
    }
}
