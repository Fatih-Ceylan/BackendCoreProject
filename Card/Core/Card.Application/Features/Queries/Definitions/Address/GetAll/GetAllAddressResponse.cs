using Card.Application.VMs;

namespace Card.Application.Features.Queries.Definitions.Address.GetAll
{
    public class GetAllAddressResponse
    {
        public int TotalCount { get; set; }
        public List<AddressVM> Addresses { get; set; }
    }
}
