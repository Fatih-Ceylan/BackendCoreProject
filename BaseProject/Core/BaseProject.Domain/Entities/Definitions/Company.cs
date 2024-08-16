using BaseProject.Domain.Entities.Definitions.Files;

namespace BaseProject.Domain.Entities.Definitions
{
    public class Company : B_BaseEntity
    {
        public Guid? MasterCompanyIdFromPlatform { get; set; }

        public Guid? MainCompanyId { get; set; }

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

        //public int? DistrictId { get; set; }

        //public District? District { get; set; }

        public ICollection<Branch> Branches { get; set; }

        public ICollection<CompanyFile> CompanyFiles { get; set; }

        public ICollection<CompanyLicense> CompanyLicenses { get; set; }

        public ICollection<CompanyAddress> CompanyAddresses { get; set; }
    }
}