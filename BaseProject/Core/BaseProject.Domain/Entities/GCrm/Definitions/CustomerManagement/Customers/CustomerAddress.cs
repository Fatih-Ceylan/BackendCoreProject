using BaseProject.Domain.Entities.Definitions;
using BaseProject.Domain.Entities.GCrm.Enums;
using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers
{
    public class CustomerAddress : BaseEntity
    {
        public Guid CustomerId { get; set; }

        public AddressTypeEnum AddressType { get; set; }

        public string Address1 { get; set; }

        public string? Address2 { get; set; }

        public int? CountryId { get; set; }

        public int? CityId { get; set; }

        public int? DistrictId { get; set; }

        public string? PostalCode { get; set; }

        public string? CountryCode { get; set; }

        public string? RegionCode { get; set; }

        //public string? Phone { get; set; } //bu

        //public string? Phone2 { get; set; } //bu

        //public string? FaxNo { get; set; } //bu

        //public string? Mobile { get; set; } //bu

        //public string Email1 { get; set; } // bu

        //public string? Email2 { get; set; } //bu

        //public string? WebAddress { get; set; } //bu

        public Customer Customer { get; set; }

        public District? District { get; set; }
    }
}
