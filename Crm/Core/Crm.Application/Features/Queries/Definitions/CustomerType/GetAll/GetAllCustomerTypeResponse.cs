using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.CustomerType.GetAll
{
    public class GetAllCustomerTypeResponse
    {
        public int TotalCount { get; set; }

        public List<CustomerTypeVM> CustomerTypes { get; set; }
    }
}
