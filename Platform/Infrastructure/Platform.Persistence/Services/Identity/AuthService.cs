using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Platform.Application.Abstractions.Services.Identity;
using Platform.Application.Abstractions.Token;
using Platform.Application.DTOs.Identity.Auth;
using Platform.Domain.Entities.Identity;
using Utilities.Core.UtilityApplication.DTOs.Identity;
using Utilities.Core.UtilityApplication.DTOs.Identity.Auth.Login;
using Utilities.Core.UtilityApplication.Exceptions;

namespace Platform.Persistence.Services.Identity
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;
        readonly IAppUserService _appUserService;
        readonly IConfiguration _config;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IAppUserService appUserService, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _appUserService = appUserService;
            _config = config;
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
                TokenDTO token = _tokenHandler.CreateAccessToken(Convert.ToInt32(_config["TokenLifeTime:AccessTokenLifeTime"]), appUser);
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
                TokenDTO tokenDTO = _tokenHandler.CreateAccessToken(Convert.ToInt32(_config["TokenLifeTime:AccessTokenLifeTime"]), appUser);
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
    }
}