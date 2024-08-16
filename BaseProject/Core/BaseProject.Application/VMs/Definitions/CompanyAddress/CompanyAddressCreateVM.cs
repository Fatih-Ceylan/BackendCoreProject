namespace BaseProject.Application.VMs.Definitions.CompanyAddress
{
    public class CompanyAddressCreateVM
    {
        public string AddressTypeId { get; set; }

        public int? CountryId { get; set; }

        public int? CityId { get; set; }

        public int? DistrictId { get; set; }

        public string? PostalCode { get; set; }

        public string? FullAddress { get; set; }

    }
}