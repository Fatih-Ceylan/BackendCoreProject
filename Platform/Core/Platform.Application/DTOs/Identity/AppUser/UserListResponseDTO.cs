using Utilities.Core.UtilityApplication.VMs;

namespace Platform.Application.DTOs.Identity.AppUser
{
    public class UserListResponseDTO
    {
        public int TotalCount { get; set; }

        public List<AppUserVM> Users { get; set; }
    }
}