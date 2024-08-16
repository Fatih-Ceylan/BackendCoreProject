using Utilities.Core.UtilityApplication.VMs;

namespace Platform.Application.Features.Queries.Identity.AppUser.GetAll
{
    public class GetAllAppUserResponse
    {
        public int TotalCount { get; set; }

        public List<AppUserVM> Users { get; set; }
    }
}