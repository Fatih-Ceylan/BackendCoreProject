using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Utilities.Core.UtilityApplication.Abstractions.Services.CurrentUser;
using Utilities.Core.UtilityApplication.DTOs.Identity.AppUser;

namespace Utilities.Infrastructure.UtilityInfrastructure.Services.CurrentUser
{
    public class CurrentUserService : ICurrentUserService
    {
        readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CurrentUserDTO> GetCurrentUser()
        {
            var currentUser = _httpContextAccessor?.HttpContext?.User;

            if (currentUser?.Identity?.IsAuthenticated == false)
                throw new Exception("User is not Authenticated");

            CurrentUserDTO currentUserDTO = new();
            currentUserDTO.Id = currentUser?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
            currentUserDTO.FullName = currentUser?.Claims?.FirstOrDefault(cu => cu.Type == "Fullname")?.Value ?? "";
            currentUserDTO.UserName = currentUser?.FindFirst(ClaimTypes.Name)?.Value ?? "";
            currentUserDTO.Email = currentUser?.FindFirst(ClaimTypes.Email)?.Value ?? "";
            currentUserDTO.UrlPath = currentUser?.Claims?.FirstOrDefault(cu => cu.Type == "UrlPath")?.Value ?? "";
            currentUserDTO.MasterCompanyIdFromPlatform = currentUser?.Claims.FirstOrDefault(cu => cu.Type == "MasterCompanyIdFromPlatform")?.Value;
            currentUserDTO.CompanyId = currentUser?.Claims?.FirstOrDefault(cu => cu.Type == "CompanyId")?.Value;
            currentUserDTO.CompanyName = currentUser?.Claims?.FirstOrDefault(cu => cu.Type == "CompanyName")?.Value;
            currentUserDTO.BranchId = currentUser?.Claims?.FirstOrDefault(cu => cu.Type == "BranchId")?.Value;
            currentUserDTO.BranchName = currentUser?.Claims?.FirstOrDefault(cu => cu.Type == "BranchName")?.Value;
            currentUserDTO.DepartmentId = currentUser?.Claims?.FirstOrDefault(cu => cu.Type == "DepartmentId")?.Value;
            currentUserDTO.DepartmentName = currentUser?.Claims?.FirstOrDefault(cu => cu.Type == "DepartmentName")?.Value;
            currentUserDTO.IdTag = currentUser?.Claims?.FirstOrDefault(cu => cu.Type == "IdTag")?.Value;

            return currentUserDTO;
        }
    }
}