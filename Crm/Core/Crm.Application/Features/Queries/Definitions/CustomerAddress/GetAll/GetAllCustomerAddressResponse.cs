using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.CustomerAddress.GetAll
{
    public class GetAllCustomerAddressResponse
    {
        public int TotalCount { get; set; }

        public List<CustomerAddressVM> CustomerAddresses { get; set; }
    }
}
