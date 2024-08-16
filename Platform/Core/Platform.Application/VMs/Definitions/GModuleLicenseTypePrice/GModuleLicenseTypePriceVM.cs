using Utilities.Core.UtilityApplication.VMs;

namespace Platform.Application.VMs.Definitions.GModuleLicenseTypePrice
{
    public class GModuleLicenseTypePriceVM : BaseVM
    {
        public string GModuleId { get; set; }

        public string GModuleName { get; set; }

        public string LicenseTypeId { get; set; }

        public string LicenseTypeName { get; set; }

        public decimal Amount { get; set; }

        public decimal TaxRate { get; set; }

        public decimal AUserPriceForAMonth { get; set; }

        public decimal ACompanyPriceForAMonth { get; set; }
    }
}