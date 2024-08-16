namespace BaseProject.Domain.Entities.Definitions
{
    public class CompanyLicense: B_BaseEntity
    {
        public Guid CompanyId { get; set; }

        public Guid LicenseId { get; set; }

        public bool IsInUse { get; set; }

        public Company Comnpany { get; set; }
    }
}