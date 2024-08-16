using GCharge.Application.DTOs.Identity.AppUser;
using GCharge.Domain.Entities.Identity;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCharge.Application.Abstractions.Identity
{
    public interface IAppUserService
    {
        Task<CreateUserResponseDTO> CreateAsync(CreateUserRequestDTO model);

        Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);

        Task<UpdateUserResponseDTO> UpdateAsync(UpdateUserRequestDTO model);

        Task<DeleteUserResponseDTO> SoftDelete(string id);

        Task<UserDTO> GetByIdAsync(string id);

        UserListDTO GetAllDeletedStatus(Pagination paginationRequest);

        Task UpdatePasswordAsync(string userId, string resetToken, string newPassword);
    }
}