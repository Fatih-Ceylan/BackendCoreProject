using AutoMapper;
using BaseProject.Application.Abstractions.Services.Identity;
using BaseProject.Application.Abstractions.Token;
using BaseProject.Application.DTOs.Identity.Auth;
using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;
using Utilities.Core.UtilityApplication.Abstractions.Services.Mail;
using Utilities.Core.UtilityApplication.DTOs.Identity;
using Utilities.Core.UtilityApplication.DTOs.Identity.Auth.Login;
using Utilities.Core.UtilityApplication.DTOs.Mail;
using Utilities.Core.UtilityApplication.Exceptions;

namespace BaseProject.Persistence.Services.Identity
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;
        readonly IAppUserService _appUserService;
        readonly IConfiguration _config;
        readonly ICompanyReadRepository _companyReadRepository;
        readonly IMailService _mailService;
        readonly IMailCredentialReadRepository _mailCredantialReadRepository;
        readonly IMapper _mapper;
        readonly IConfiguration _configuration;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IAppUserService appUserService, IConfiguration config, ICompanyReadRepository companyReadRepository, IMailService mailService, IMailCredentialReadRepository mailCredantialReadRepository, IMapper mapper, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _appUserService = appUserService;
            _config = config;
            _companyReadRepository = companyReadRepository;
            _mailService = mailService;
            _mailCredantialReadRepository = mailCredantialReadRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO model)
        {
            AppUser? appUser = await _userManager.FindByNameAsync(model.UserNameOrEmail);
            if (appUser == null)
            {
                await _userManager.FindByEmailAsync(model.UserNameOrEmail);
            }
            if (appUser == null || appUser.IsDeleted == true)
            {
                throw new NotFoundUserEcxeption();
            }
            //TODO: şifre kilitleme canlıya alınırken açılacak

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(appUser, model.Password, false);
            if (result.Succeeded) // Authentication başarılı!
            {
                TokenDTO token = await _tokenHandler.CreateAccessTokenAsync(Convert.ToInt32(_config["TokenLifeTime:AccessTokenLifeTime"]), appUser, model.UrlPath, model.MasterCompanyIdFromPlatform);
                await _appUserService.UpdateRefreshTokenAsync(token.RefreshToken, appUser, token.ExpiryDate, Convert.ToInt32(_config["TokenLifeTime:AddToAccessTokenEndDate"]));

                return new()
                {
                    Token = token
                };
            }
            else
            {
                throw new AuthenticationErrorException();
            }
        }

        public async Task<LoginResponseDTO> RefreshTokenLoginAsync(string refreshToken, string urlPath, string masterCompanyIdFromPlatform)
        {
            AppUser? appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (appUser != null && appUser?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                TokenDTO tokenDTO = await _tokenHandler.CreateAccessTokenAsync(Convert.ToInt32(_config["TokenLifeTime:AccessTokenLifeTime"]), appUser, urlPath, masterCompanyIdFromPlatform);
                await _appUserService.UpdateRefreshTokenAsync(refreshToken, appUser, tokenDTO.ExpiryDate, Convert.ToInt32(_config["TokenLifeTime:AddToAccessTokenEndDate"]));

                return new()
                {
                    Token = tokenDTO
                };
            }
            else if (appUser == null)
            {
                throw new NotFoundUserEcxeption();
            }
            else
                throw new TokenExpiryDateException();
        }


        public async Task PasswordResetAsync(string email)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(email);
            if (appUser != null)
            {
                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(appUser);
                byte[] tokenBytes = Encoding.UTF8.GetBytes(resetToken);
                resetToken = WebEncoders.Base64UrlEncode(tokenBytes);

                var mainCompany = _companyReadRepository.GetWhere(c => c.MainCompanyId == null).FirstOrDefault();
                if (mainCompany == null)
                    throw new Exception("Main Company was not found.");

                var mailCredantial = _mailCredantialReadRepository.GetWhere(mc => mc.CompanyId == mainCompany.Id).FirstOrDefault();
                if (mailCredantial == null)
                    throw new Exception("Main Company Mail Credantial was not found.");

                var mailCredantialDto = _mapper.Map<MailCredentialDTO>(mailCredantial);
                MailOptionDTO mailOption = new();

                ResetPasswordDTO resetPassword = new();

                resetPassword.MailCredential = mailCredantialDto;
                resetPassword.MailOption = mailOption;
                resetPassword.UserId = appUser.Id;
                resetPassword.UserEmail = email;
                resetPassword.ResetToken = resetToken;
                resetPassword.MainCompanyName = mainCompany.Name;

                await SendPasswordResetMailAsync(resetPassword);
            }
            else
                throw new NotFoundUserEcxeption();
        }

        public async Task SendPasswordResetMailAsync(ResetPasswordDTO resetPassword)
        {
            //todo url'i appsettings'den çek
            StringBuilder mail = new();
            mail.AppendLine("Merhaba<br>Eğer yeni şifre talebinde bulunduysanız aşağıdaki linkten şifrenizi yenileybilirsiniz.<br><strong><a target=\"_blank\" href=\"");
            mail.Append(_configuration["ResetPasswordClientUrl"]);
            mail.Append("/reset-password/");
            mail.Append(resetPassword.UserId);
            mail.Append("/");
            mail.Append(resetPassword.ResetToken);
            mail.Append("\">Yeni şifre oluşturmak için tıklayınız...</a></strong><br><br><span style=\"font-size:12px;\">NOT : Eğer ki bu talep tarafınızca gerçekleştirilmemişse lütfen maili dikkate almayınız.</span><br>Saygılarımızla...<br><br><br>");
            mail.Append("<img src=\"http://localhost:5000/Company-Files/olcerholdinglogo.jpg\" width=\"200\" height=\"150\" alt=\"Şirket Logosu\"><br><h2>");
            mail.Append(resetPassword.MainCompanyName);
            mail.Append(" - Platformu</h2>");

            resetPassword.MailOption.To = new string[] { resetPassword.UserEmail };
            resetPassword.MailOption.Subject = "Şifre Yenileme Talebi";
            resetPassword.MailOption.Body = mail.ToString();

            await _mailService.SendEMmailAsync(resetPassword.MailCredential, resetPassword.MailOption);
        }

        public async Task<bool> VerifyResetTokenAsync(string resetToken, string userId)
        {
            AppUser appUser = await _userManager.FindByIdAsync(userId);
            if (appUser != null)
            {
                byte[] tokenBytes = WebEncoders.Base64UrlDecode(resetToken);
                resetToken = Encoding.UTF8.GetString(tokenBytes);

                return await _userManager.VerifyUserTokenAsync(appUser, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", resetToken);
            }
            else
                throw new NotFoundUserEcxeption();
        }
    }
}