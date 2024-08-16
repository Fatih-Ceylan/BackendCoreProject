using Platform.Application.VMs.Definitions.LicenseDetail;
using Utilities.Core.UtilityApplication.VMs;

namespace Platform.Application.VMs.Definitions.License
{
    public class LicenseWithLicenseDetailListVM : BaseVM
    {
        public string CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string GModuleId { get; set; }

        public string GModuleName { get; set; }

        public string LicenseTypeId { get; set; }

        public string LicenseTypeName { get; set; }

        public string LicenseKey { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int RemainingUsageDays { get; set; }

        public int TotalCompanyNumber { get; set; }

        public int TotalUserNumber { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public decimal LicenseDetailsTotalAmount { get; set; }

        public decimal LicenseDetailTaxRate { get; set; }

        public List<LicenseDetailVM> LicenseDetails { get; set; }
    }
}