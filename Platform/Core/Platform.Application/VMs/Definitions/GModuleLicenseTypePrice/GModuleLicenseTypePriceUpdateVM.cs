namespace Platform.Application.VMs.Definitions.GModuleLicenseTypePrice
{
    public class GModuleLicenseTypePriceUpdateVM
    {
        public string Id { get; set; }

        public string GModuleId { get; set; }

        public string LicenseTypeId { get; set; }

        public string LicenseTypeName { get; set; }

        public int LicenseTypeUsageMounth { get; set; }

        public int LicenseTypeUserNumber { get; set; }

        public int LicenseTypeCompanyNumber { get; set; }

        public decimal Amount { get; set; }

        public decimal TaxRate { get; set; }

        public decimal AUserPriceForAMonth { get; set; }

        public decimal ACompanyPriceForAMonth { get; set; }
    }
}