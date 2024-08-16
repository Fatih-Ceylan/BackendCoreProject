using MediatR;

namespace BaseProject.Application.Features.Commands.Definitions.CompanyAddress.Create
{
    public class CreateCompanyAddressRequest: IRequest<CreateCompanyAddressResponse>
    {
        public string CompanyId { get; set; }

        public string AddressTypeId { get; set; }

        public string? FullAddress { get; set; }

        public string? PostalCode { get; set; }

        public int? CountryId { get; set; }

        public int? CityId { get; set; }

        public int? DistrictId { get; set; }
    }
}