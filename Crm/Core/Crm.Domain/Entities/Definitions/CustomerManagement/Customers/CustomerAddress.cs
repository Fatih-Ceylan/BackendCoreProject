using GCrm.Domain.Enums;
using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.Definitions.CustomerManagement.Customers
{
    public class CustomerAddress : BaseEntity
    {
        public Guid CustomerId { get; set; }

        public AddressTypeEnum AddressType { get; set; }

        public string Address1 { get; set; }

        public string? Address2 { get; set; }

        public Guid? CountryId { get; set; }

        public Guid? CityId { get; set; }

        public Guid? DistrictId { get; set; }

        public string? PostalCode { get; set; }

        public string? CountryCode { get; set; }

        public string? RegionCode { get; set; }

        public string? Phone { get; set; }

        public string? Phone2 { get; set; }

        public string? FaxNo { get; set; }

        public string? Mobile { get; set; }

        public string Email1 { get; set; }

        public string? Email2 { get; set; }

        public string? WebAddress { get; set; }

        public Customer Customer { get; set; }

        public District District { get; set; }
    }
}
