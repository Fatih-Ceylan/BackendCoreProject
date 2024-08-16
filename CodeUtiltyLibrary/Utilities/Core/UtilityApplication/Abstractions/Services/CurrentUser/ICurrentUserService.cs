using Utilities.Core.UtilityApplication.DTOs.Identity.AppUser;

namespace Utilities.Core.UtilityApplication.Abstractions.Services.CurrentUser
{
    public interface ICurrentUserService
    {
        Task<CurrentUserDTO> GetCurrentUser();
    }
}
