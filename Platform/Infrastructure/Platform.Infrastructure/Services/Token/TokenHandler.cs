using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Platform.Application.Abstractions.Token;
using Platform.Domain.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Utilities.Core.UtilityApplication.DTOs.Identity;

namespace Platform.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenDTO CreateAccessToken(int second, AppUser appUser)
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

            audienceClaims.Add(new(ClaimTypes.NameIdentifier, appUser.Id));
            audienceClaims.Add(new(ClaimTypes.Name, appUser.UserName));
            audienceClaims.Add(new(ClaimTypes.Email, appUser.Email));

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
