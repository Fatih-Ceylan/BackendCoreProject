using Utilities.Core.UtilityDomain.Entities;

namespace Platform.Domain.Entities.Definitions
{
    public class GModuleLicenseTypePrice: BaseEntity
    {
        public Guid GModuleId { get; set; }

        public Guid LicenseTypeId { get; set; }

        public decimal Amount { get; set; }

        public decimal TaxRate { get; set; }

        public decimal AUserPriceForAMonth { get; set; }

        public decimal ACompanyPriceForAMonth { get; set; }

        public GModule GModule { get; set; }

        public LicenseType LicenseType { get; set; }
    }
}