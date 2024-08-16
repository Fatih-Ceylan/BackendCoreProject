using BaseProject.Application.DTOs.Identity.AppUser;

namespace Platform.Api.Services.BaseProject
{
    public interface IBaseProjectService
    {
        Task<string> AddUser(CreateUserRequestDTO user, string accessToken, string routeName);

        Task<string> SoftDeleteAllUsers(string accessToken, string routeName);
    }
}