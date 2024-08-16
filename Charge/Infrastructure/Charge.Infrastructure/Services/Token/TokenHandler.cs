using GCharge.Application.Abstractions.Token;
using GCharge.Application.Repositories.ReadRepository.Definitions;
using GCharge.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Utilities.Core.UtilityApplication.DTOs.Identity;

namespace GCharge.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;
        readonly IUserChargeTagReadRepository _userChargeTagReadRepository;
        private readonly UserManager<AppUser> _userManager;

        public TokenHandler(IConfiguration configuration, IUserChargeTagReadRepository userChargeTagReadRepository, UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            _userChargeTagReadRepository = userChargeTagReadRepository;
            _userManager = userManager;
        }

        public async Task<TokenDTO> CreateAccessToken(int second, AppUser appUser)
        {
            TokenDTO tokenDTO = new TokenDTO();

            //Security Key'in simetriğini alıyoruz.
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            //Şifrelenmiş kimliği oluşturuyoruz.
            SigningCredentials signingCredentiales = new(securityKey, SecurityAlgorithms.HmacSha256);

            //oluşturulacak token ayarlarını veriyoruz.
            var audiences = _configuration.GetSection("Token:Audience").Get<string[]>();

            List<Claim> audienceClaims = new();
            foreach (var audience in audiences)
            {
                audienceClaims.Add(new Claim("aud", audience));
            }

            audienceClaims.Add(new Claim("Fullname", appUser.FullName));
            audienceClaims.Add(new(ClaimTypes.NameIdentifier, appUser.Id));
            audienceClaims.Add(new(ClaimTypes.Name, appUser.UserName));
            audienceClaims.Add(new(ClaimTypes.Email, appUser.Email));

            var  roles =  await _userManager.GetRolesAsync(appUser);
            audienceClaims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));


            var userChargeTag = _userChargeTagReadRepository.GetWhere(x => x.UserId == appUser.Id).FirstOrDefault();
            audienceClaims.Add(new Claim("IdTag", userChargeTag != null ? userChargeTag.TagId : ""));

            tokenDTO.ExpiryDate = DateTime.UtcNow.AddSeconds(second);
            JwtSecurityToken securityToken = new(
                issuer: _configuration["Token:Issuer"],
                expires: tokenDTO.ExpiryDate,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentiales,
                claims: audienceClaims
                );

            //Token oluşturucu sınıfından bir örnek alınacak.
            JwtSecurityTokenHandler tokenHandler = new();
            tokenDTO.AccessToken = tokenHandler.WriteToken(securityToken);

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
