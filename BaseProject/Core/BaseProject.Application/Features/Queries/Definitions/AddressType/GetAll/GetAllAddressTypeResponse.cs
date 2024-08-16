using BaseProject.Application.VMs.Definitions.AddressType;

namespace BaseProject.Application.Features.Queries.Definitions.AddressType.GetAll
{
    public class GetAllAddressTypeResponse
    {
        public int TotalCount { get; set; }

        public List<AddressTypeVM> AddressTypes { get; set; }
    }
}