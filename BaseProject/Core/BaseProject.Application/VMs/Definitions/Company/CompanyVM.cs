using BaseProject.Application.VMs.Definitions.CompanyAddress;
using BaseProject.Application.VMs.Definitions.CompanyLicense;
using Utilities.Core.UtilityApplication.VMs;

namespace BaseProject.Application.VMs.Definitions.Company
{
    public class CompanyVM : BaseVM
    {
        public string? MasterCompanyIdFromPlatform { get; set; }

        public string? MainCompanyId { get; set; }

        public string? MainCompanyName { get; set; }

        public string? LogoPath { get; set; }

        public string Name { get; set; }

        public string AuthorizedFullName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? FaxNo { get; set; }

        public string? Email { get; set; }

        public string? WebAddress { get; set; }

        public string? TaxOffice { get; set; }

        public string? TaxNo { get; set; }

        public string? TradeRegisterNo { get; set; }

        public string? SocialSecurityNo { get; set; }

        public string? MersisNo { get; set; }

        public List<CompanyLicenseCreateVM>? CompanyLicenses { get; set; }

        public List<CompanyAddressVM>? CompanyAddresses { get; set; }
    }
}