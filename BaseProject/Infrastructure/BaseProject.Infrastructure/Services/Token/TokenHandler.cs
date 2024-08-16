using BaseProject.Application.Abstractions.Services.Definitions;
using BaseProject.Application.Abstractions.Token;
using BaseProject.Application.Repositories.ReadRepository.Identity;
using BaseProject.Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Utilities.Core.UtilityApplication.DTOs.Identity;

namespace BaseProject.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;
        readonly IDepartmentService _departmentService;
        readonly IAppUserAppellationReadRepository _appUserAppellationReadRepository;

        public TokenHandler(IConfiguration configuration, IDepartmentService departmentService, IAppUserAppellationReadRepository appUserAppellationReadRepository)
        {
            _configuration = configuration;
            _departmentService = departmentService;
            _appUserAppellationReadRepository = appUserAppellationReadRepository;
        }

        public async Task<TokenDTO> CreateAccessTokenAsync(int seconds, AppUser appUser, string urlPath, string masterCompanyIdFromPlatform)
        {
            TokenDTO tokenDTO = new TokenDTO();

            // Get symmetric security key from configuration
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            // Create signing credentials for the token
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            // Get audience claims from configuration
            var audiences = _configuration.GetSection("Token:Audience").Get<string[]>();

            List<Claim> audienceClaims = new List<Claim>();

            // Iterate over audiences and add claims
            foreach (var audience in audiences)
            {
                audienceClaims.Add(new Claim("aud", audience));
            }

            // Retrieve AppUserAppellation asynchronously
            AppUserAppellation appUserAppellation = null;
            if (!string.IsNullOrEmpty(appUser.AppUserAppellationId.ToString()))
            {
                appUserAppellation = await _appUserAppellationReadRepository.GetByIdAsync(appUser.AppUserAppellationId.ToString());
            }

            // Retrieve department asynchronously
            var department = appUser.DepartmentId != null ? _departmentService.GetDepartmentById(appUser.DepartmentId.ToString()) : null;

            // Add required claims to audienceClaims
            audienceClaims.Add(new Claim("UrlPath", urlPath));
            audienceClaims.Add(new Claim("MasterCompanyIdFromPlatform", masterCompanyIdFromPlatform));
            audienceClaims.Add(new Claim("Fullname", appUser.FullName));
            audienceClaims.Add(new Claim("CompanyId", appUser.CompanyId.ToString() ?? ""));
            audienceClaims.Add(new Claim("CompanyName", department?.CompanyName ?? ""));
            audienceClaims.Add(new Claim("BranchId", appUser.BranchId.ToString() ?? ""));
            audienceClaims.Add(new Claim("BranchName", department?.BranchName ?? ""));
            audienceClaims.Add(new Claim("DepartmentId", appUser.DepartmentId.ToString() ?? ""));
            audienceClaims.Add(new Claim("DepartmentName", department?.Name ?? ""));
            audienceClaims.Add(new Claim("AppellationId", appUserAppellation?.Id.ToString() ?? ""));
            audienceClaims.Add(new Claim("Appellation", appUserAppellation?.Name ?? ""));
            audienceClaims.Add(new Claim("ProfileImagePath", appUser.ProfileImagePath ?? ""));

            audienceClaims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id));
            audienceClaims.Add(new Claim(ClaimTypes.Name, appUser.UserName));
            audienceClaims.Add(new Claim(ClaimTypes.Email, appUser.Email));

            // Set token expiration date
            tokenDTO.ExpiryDate = DateTime.UtcNow.AddSeconds(seconds);

            // Create JWT security token
            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: _configuration["Token:Issuer"],
                expires: tokenDTO.ExpiryDate,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials,
                claims: audienceClaims
            );

            // Generate access token
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            tokenDTO.AccessToken = tokenHandler.WriteToken(securityToken);

            // Generate refresh token
            tokenDTO.RefreshToken = CreateRefreshToken();

            return tokenDTO;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);

            return Convert.ToBase64String(number);
        }
    }
}
