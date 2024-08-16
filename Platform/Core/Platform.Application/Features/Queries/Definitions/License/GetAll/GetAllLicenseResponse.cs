using Platform.Application.VMs.Definitions.License;

namespace Platform.Application.Features.Queries.Definitions.License.GetAll
{
    public class GetAllLicenseResponse
    {
        public int TotalCount { get; set; }
        public List<LicenseVM> Licenses { get; set; }
    }
}
