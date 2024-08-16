using Platform.Application.VMs.Definitions.SpecialOffer;
using Utilities.Core.UtilityApplication.VMs;

namespace Platform.Application.VMs.Definitions.LicenseDetail
{
    public class LicenseDetailVM: BaseVM
    {
        public SpecialOfferInLicenseDetailVM? SpecialOffer { get; set; }

        public string LicenseStatus { get; set; }

        public string Description { get; set; }

        public int Number { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Amount { get; set; }

        public decimal TaxRate { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime StartDate { get; set; }

    }
}