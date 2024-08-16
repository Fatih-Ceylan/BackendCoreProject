using AutoMapper;
using GCharge.Application.Abstractions.Identity;
using GCharge.Application.Abstractions.Token;
using GCharge.Application.DTOs.Identity.Auth;
using GCharge.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;
using Utilities.Core.UtilityApplication.Abstractions.Services.Mail;
using Utilities.Core.UtilityApplication.DTOs.Identity;
using Utilities.Core.UtilityApplication.DTOs.Identity.Auth.Login;
using Utilities.Core.UtilityApplication.Exceptions;

namespace GCharge.Persistence.Services.Identity
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;
        readonly IAppUserService _appUserService;
        readonly IConfiguration _config;
        readonly IMailService _mailService;
        readonly IMapper _mapper;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IAppUserService appUserService, IConfiguration config,  IMailService mailService, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _appUserService = appUserService;
            _config = config;
            _mailService = mailService;
            _mapper = mapper;
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO model)
        {
            AppUser? appUser = await _userManager.FindByNameAsync(model.UserNameOrEmail);
            if (appUser == null)
            {
                appUser = await _userManager.FindByEmailAsync(model.UserNameOrEmail);
            }
            if (appUser == null || appUser.IsDeleted == true)
            {
                throw new NotFoundUserEcxeption();
            }
            //TODO: şifre kilitleme canlıya alınırken açılacak

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(appUser, model.Password, false);
            if (result.Succeeded) // Authentication başarılı!
            {
                TokenDTO token = await _tokenHandler.CreateAccessToken(Convert.ToInt32(_config["TokenLifeTime:AccessTokenLifeTime"]), appUser);
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

        public async Task<LoginResponseDTO> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser? appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (appUser != null && appUser?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                TokenDTO tokenDTO = await _tokenHandler.CreateAccessToken(Convert.ToInt32(_config["TokenLifeTime:AccessTokenLifeTime"]), appUser);
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
                //string resetToken = await _userManager.GeneratePasswordResetTokenAsync(appUser);
                //byte[] tokenBytes = Encoding.UTF8.GetBytes(resetToken);
                //resetToken = WebEncoders.Base64UrlEncode(tokenBytes);

                //var mainCompany = _companyReadRepository.GetWhere(c => c.MainCompanyId == null).FirstOrDefault();
                //if (mainCompany == null)
                //    throw new Exception("Main Company was not found.");

                //var mailCredential = _mailCredentialReadRepository.GetWhere(mc => mc.CompanyId == mainCompany.Id).FirstOrDefault();
                //if (mailCredential == null)
                //    throw new Exception("Main Company Mail Credential was not found.");

                //var mailCredentialDto = _mapper.Map<MailCredentialDTO>(mailCredential);
                //MailOptionDTO mailOption = new();

                //ResetPasswordDTO resetPassword = new();

                //resetPassword.MailCredential = mailCredentialDto;
                //resetPassword.MailOption = mailOption;
                //resetPassword.UserId = appUser.Id;
                //resetPassword.UserEmail = email;
                //resetPassword.ResetToken = resetToken;
                //resetPassword.MainCompanyName = mainCompany.Name;

                //await _mailService.SendPasswordResetMailAsync(resetPassword);
            }
            else
                throw new NotFoundUserEcxeption();
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