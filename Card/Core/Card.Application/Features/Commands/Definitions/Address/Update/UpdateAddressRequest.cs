using MediatR;

namespace Card.Application.Features.Commands.Definitions.Address.Update
{
    public class UpdateAddressRequest : IRequest<UpdateAddressResponse>
    {
        public string Id { get; set; }
        public string AddressLine { get; set; }
        public string AddressType { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
    }
}
