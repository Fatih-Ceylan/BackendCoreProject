using MediatR;

namespace Card.Application.Features.Commands.Definitions.Address.Create
{
    public class CreateAddressRequest : IRequest<CreateAddressResponse>
    {
        public string CountryId { get; set; }
        public string CityId { get; set; }
        public string DistrictId { get; set; }
        public string AddressLine { get; set; }
        public string AddressType { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
    }
}
