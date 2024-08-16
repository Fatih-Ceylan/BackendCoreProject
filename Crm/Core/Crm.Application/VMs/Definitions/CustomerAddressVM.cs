using BaseProject.Domain.Entities.GCrm.Enums;
using Utilities.Core.UtilityApplication.VMs;

namespace GCrm.Application.VMs.Definitions
{
    public class CustomerAddressVM : BaseVM
    {
        public string CustomerId { get; set; }

        public string CustomerName { get; set; }

        public AddressTypeEnum AddressType { get; set; }

        public string Address1 { get; set; }

        public string? Address2 { get; set; }

        public int? CountryId { get; set; }

        public string CountryName { get; set; }

        public int? CityId { get; set; }

        public string CityName { get; set; }

        public int? DistrictId { get; set; }

        public string DistrictName { get; set; }

        public string? PostalCode { get; set; }

        public string? CountryCode { get; set; }

        public string? RegionCode { get; set; }

        //public string? Phone { get; set; }

        //public string? Phone2 { get; set; }

        //public string? FaxNo { get; set; }

        //public string? Mobile { get; set; }

        //public string Email1 { get; set; }

        //public string? Email2 { get; set; }

        //public string? WebAddress { get; set; }
    }
}
