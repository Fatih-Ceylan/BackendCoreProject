using Utilities.Core.UtilityApplication.VMs;

namespace BaseProject.Application.VMs.Definitions.CompanyAddress
{
    public class CompanyAddressVM: BaseVM
    {
        public string CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string AddressTypeId { get; set; }

        public string AddressTypeName { get; set; }

        public string? FullAddress { get; set; }

        public string? PostalCode { get; set; }

        public int? CountryId { get; set; }

        public string? CountryName { get; set; }

        public int? CityId { get; set; }

        public string? CityName { get; set; }

        public int? DistrictId { get; set; }

        public string? DistrictName { get; set; }
    }
}