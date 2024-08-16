using Platform.Domain.Entities.Identity;
using Utilities.Core.UtilityApplication.DTOs.Identity;

namespace Platform.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        TokenDTO CreateAccessToken(int second, AppUser appUser);
        string CreateRefreshToken();
    }
}