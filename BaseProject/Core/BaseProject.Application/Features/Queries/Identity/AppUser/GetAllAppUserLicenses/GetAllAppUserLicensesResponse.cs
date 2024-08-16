using BaseProject.Application.VMs.Definitions.AppUserLicense;

namespace BaseProject.Application.Features.Queries.Identity.AppUser.GetAllAppUserLicenses
{
    public class GetAllAppUserLicensesResponse
    {
        public int TotalCount { get; set; }

        public List<AppUserLicenseCreateVM> AppUserLicenses { get; set; }
    }
}