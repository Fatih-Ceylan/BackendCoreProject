using Platform.Application.VMs.Definitions.LicenseType;

namespace Platform.Application.Features.Queries.Definitions.LicenseType.GetAll
{
    public class GetAllLicenseTypeResponse
    {
        public int TotalCount { get; set; }

        public List<LicenseTypeVM> LicenseTypes { get; set; }
    }
}