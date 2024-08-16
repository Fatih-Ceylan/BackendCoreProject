using Utilities.Core.UtilityDomain.Entities;

namespace Platform.Domain.Entities.Definitions
{
    public class License : BaseEntity
    {
        public Guid CompanyId { get; set; }

        public Guid GModuleId { get; set; }

        public Guid LicenseTypeId { get; set; }

        public Guid LicenseKey { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int TotalCompanyNumber { get; set; }

        public int TotalUserNumber { get; set; }

        public Company Company { get; set; }

        public GModule GModule { get; set; }

        public LicenseType LicenseType { get; set; }

        public ICollection<LicenseDetail> LicenseDetails { get; set; }
    }
}