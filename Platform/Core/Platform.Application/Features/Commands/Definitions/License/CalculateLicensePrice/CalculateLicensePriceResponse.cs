using Platform.Application.VMs.Definitions.LicenseDetail;

namespace Platform.Application.Features.Commands.Definitions.License.CalculateLicensePrice
{
    public class CalculateLicensePriceResponse
    {
        public decimal LicenseDetailsTotalAmount { get; set; }

        public List<CreateLicenseDetailVM> LicenseDetails { get; set; }
    }
}