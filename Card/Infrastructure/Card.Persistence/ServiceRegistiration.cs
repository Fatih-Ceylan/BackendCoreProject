using BaseProject.Persistence.Contexts;
using Card.Application.Abstractions.Mail;
using Card.Application.Abstractions.Services.QrCode;
using Card.Application.Repositories.ReadRepository;
using Card.Application.Repositories.WriteRepository;
using Card.Persistence.Mail;
using Card.Persistence.Repositories.ReadRepository;
using Card.Persistence.Repositories.ReadRepository.Files;
using Card.Persistence.Repositories.WriteRepository;
using Card.Persistence.Repositories.WriteRepository.Files;
using Card.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;
using Platform.Application.Abstractions.Services.Definitions;
using Platform.Persistence.Contexts;
using Platform.Persistence.Services.Definitions;
using P = Platform.Application.Repositories.WriteRepository.Definitions;
using PP = Platform.Persistence.Repositories.WriteRepository.Definitions;

namespace Card.Persistence
{
    public static class ServiceRegistiration
    {
        public static void AddCardPersistenceServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddDbContext<BaseProjectDbContext>().AddDbContext<PlatformDbContext>();

            //#region AppUser
            //services.AddScoped<IAppUserService, AppUserService>();
            //services.AddScoped<IAuthService, AuthService>();
            //#endregion

            #region Definitions

            #region Staff

            services.AddScoped<IStaffReadRepository, StaffReadRepository>();
            services.AddScoped<IStaffWriteRepository, StaffWriteRepository>();
            #endregion

            #region Iban

            services.AddScoped<IIbanReadRepository, IbanReadRepository>();
            services.AddScoped<IIbanWriteRepository, IbanWriteRepository>();

            #endregion

            #region PhoneNumber

            services.AddScoped<IPhoneNumberReadRepository, PhoneNumberReadRepository>();
            services.AddScoped<IPhoneNumberWriteRepository, PhoneNumberWriteRepository>();

            #endregion

            #region SocialMedia

            services.AddScoped<ISocialMediaReadRepository, SocialMediaReadRepository>();
            services.AddScoped<ISocialMediaWriteRepository, SocialMediaWriteRepository>();

            #endregion

            #region SocialMediaUrl

            services.AddScoped<ISocialMediaUrlReadRepository, SocialMediaUrlReadRepository>();
            services.AddScoped<ISocialMediaUrlWriteRepository, SocialMediaUrlWriteRepository>();

            #endregion

            #region StaffContact

            services.AddScoped<IStaffContactReadRepository, StaffContactReadRepository>();
            services.AddScoped<IStaffContactWriteRepository, StaffContactWriteRepository>();

            #endregion

            #region StaffField

            services.AddScoped<IStaffFieldReadRepository, StaffFieldReadRepository>();
            services.AddScoped<IStaffFieldWriteRepository, StaffFieldWriteRepository>();

            #endregion

            #region Field

            services.AddScoped<IFieldReadRepository, FieldReadRepository>();
            services.AddScoped<IFieldWriteRepository, FieldWriteRepository>();

            #endregion

            #region Files
            services.AddScoped<IStaffFileReadRepository, StaffFileReadRepository>();
            services.AddScoped<IStaffFileWriteRepository, StaffFileWriteRepository>();
            #endregion

            #region Card

            services.AddScoped<ICardReadRepository, CardReadRepository>();
            services.AddScoped<ICardWriteRepository, CardWriteRepository>();

            #endregion 

            #region PasswordRemake

            services.AddScoped<IPasswordRemakeReadRepository, PasswordRemakeReadRepository>();
            services.AddScoped<IPasswordRemakeWriteRepository, PasswordRemakeWriteRepository>();

            #endregion

            #region Cargo

            services.AddScoped<ICargoReadRepository, CargoReadRepository>();
            services.AddScoped<ICargoWriteRepository, CargoWriteRepository>();

            #endregion 

            #region Order

            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

            #endregion 

            #region OrderDetail

            services.AddScoped<IOrderDetailReadRepository, OrderDetailReadRepository>();
            services.AddScoped<IOrderDetailWriteRepository, OrderDetailWriteRepository>();

            #endregion 

            #region Address

            services.AddScoped<IAddressReadRepository, AddressReadRepository>();
            services.AddScoped<IAddressWriteRepository, AddressWriteRepository>();

            #endregion 

            #endregion

            #region Mail

            services.AddScoped<IMailService, MailService>();

            #endregion

            #region QrCode

            services.AddScoped<IQrCodeService, QrCodeService>();

            #endregion

            #region Platform

            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IOrderService, Platform.Persistence.Services.Definitions.OrderService>();
            services.AddScoped<P.IOrderDetailWriteRepository, PP.OrderDetailWriteRepository>();
            services.AddScoped<P.IOrderWriteRepository, PP.OrderWriteRepository>();

            #endregion


        }
    }
}
