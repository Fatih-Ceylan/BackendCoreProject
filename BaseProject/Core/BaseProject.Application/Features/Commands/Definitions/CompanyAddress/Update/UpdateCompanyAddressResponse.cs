namespace BaseProject.Application.Features.Commands.Definitions.CompanyAddress.Update
{
    public class UpdateCompanyAddressResponse
    {
        public string Id { get; set; }

        public string CompanyId { get; set; }

        public string AddressTypeId { get; set; }

        public string? FullAddress { get; set; }

        public string? PostalCode { get; set; }

        public int? CountryId { get; set; }

        public int? CityId { get; set; }

        public int? DistrictId { get; set; }

        public string Message { get; set; }

    }
}