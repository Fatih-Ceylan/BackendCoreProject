using Platform.Domain.Entities.Definitions.Files;
using System.ComponentModel.DataAnnotations;
using Utilities.Core.UtilityDomain.Entities;

namespace Platform.Domain.Entities.Definitions
{
    public class Company : BaseEntity
    {
        [MaxLength(256)]
        public string? LogoPath { get; set; }

        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string BaseDbName { get; set; }

        [MaxLength(15)]
        public string UrlPath { get; set; }

        [MaxLength(50)]
        public string AuthorizedFullName { get; set; }

        [MaxLength(256)]
        public string? FullAddress { get; set; }

        [MaxLength(10)]
        public string? PostalCode { get; set; }

        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

        [MaxLength(20)]
        public string? FaxNo { get; set; }

        [MaxLength(50)]
        public string? Email { get; set; }

        [MaxLength(50)]
        public string? WebAddress { get; set; }

        [MaxLength(20)]
        public string? TaxOffice { get; set; }

        [MaxLength(15)]
        public string? TaxNo { get; set; }

        [MaxLength(50)]
        public string? TradeRegisterNo { get; set; }

        [MaxLength(50)]
        public string? SocialSecurityNo { get; set; }

        [MaxLength(50)]
        public string? MersisNo { get; set; }

        [MaxLength(50)]
        public string AdminUserFullName { get; set; }

        [MaxLength(70)]
        public string AdminUserEmail { get; set; }

        [MaxLength(50)]
        public string? District { get; set; }

        [MaxLength(50)]
        public string? City { get; set; }

        [MaxLength(50)]
        public string? Country { get; set; }

        public ICollection<License> Licenses { get; set; }

        public ICollection<CompanyFile> CompanyFiles { get; set; }

        public ICollection<SpecialOffer> SpecialOffers { get; set; }
    }
}