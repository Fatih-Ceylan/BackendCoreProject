using Platform.Application.DTOs.Identity.AppUser;
using Platform.Domain.Entities.Identity;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace Platform.Application.Abstractions.Services.Identity
{
    public interface IAppUserService
    {
        Task<CreateUserResponseDTO> CreateAsync(CreateUserRequestDTO model);

        Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);

        Task<UpdateUserResponseDTO> UpdateAsync(UpdateUserRequestDTO model);

        Task<UpdateUserResponseDTO> SoftDelete(string id);

        Task<UserResponseDTO> GetByIdAsync(string id);

        UserListResponseDTO GetAllDeletedStatus(Pagination pagination);

    }
}