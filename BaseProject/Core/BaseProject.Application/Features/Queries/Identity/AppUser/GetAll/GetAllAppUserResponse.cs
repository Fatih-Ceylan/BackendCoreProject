using BaseProject.Application.VMs.Definitions.AppUser;

namespace BaseProject.Application.Features.Queries.Identity.AppUser.GetAll
{
    public class GetAllAppUserResponse
    {
        public int TotalCount { get; set; }

        public List<AppUserVM> AppUsers { get; set; }
    }
}