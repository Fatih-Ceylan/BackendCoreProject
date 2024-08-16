using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.CustomerGroup.GetAll
{
    public  class GetAllCustomerGroupResponse
    {
        public int TotalCount { get; set; }
        public List<CustomerGroupVM>  CustomerGroups { get; set; }
    }
}
