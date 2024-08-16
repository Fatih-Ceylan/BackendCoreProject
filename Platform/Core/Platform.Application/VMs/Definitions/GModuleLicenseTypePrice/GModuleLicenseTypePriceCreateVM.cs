namespace Platform.Application.VMs.Definitions.GModuleLicenseTypePrice
{
    public class GModuleLicenseTypePriceCreateVM
    {
        public string LicenseTypeId { get; set; }

        public decimal Amount { get; set; }

        public decimal TaxRate { get; set; }

        public decimal AUserPriceForAMonth { get; set; }

        public decimal ACompanyPriceForAMonth { get; set; }
    }
}
