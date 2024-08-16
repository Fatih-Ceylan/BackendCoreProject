using BaseProject.Application.VMs.Platform.Definitions;

namespace BaseProject.Application.DTOs.Platform.Definitions.License
{
    public class GetAllLicensesResponseDto
    {
        public int TotalCount { get; set; }

        public List<LicenseVM> Licenses { get; set; }
    }
}
