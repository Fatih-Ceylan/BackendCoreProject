using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.CustomerStatus.GetAll
{
    public class GetAllCustomerStatusResponse
    {
        public int TotalCount { get; set; }

        public List<CustomerStatusVM> CustomersStatus { get; set; }
    }
}
